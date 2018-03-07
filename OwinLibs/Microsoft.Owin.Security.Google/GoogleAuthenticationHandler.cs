// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

// OpenID is obsolete
#pragma warning disable 618

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.Google.Infrastructure;
using Microsoft.Owin.Security.Infrastructure;

namespace Microsoft.Owin.Security.Google
{
    internal class GoogleAuthenticationHandler : AuthenticationHandler<GoogleAuthenticationOptions>
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        public GoogleAuthenticationHandler(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public override async Task<bool> InvokeAsync()
        {
            if (Options.CallbackPath.HasValue && Options.CallbackPath == Request.Path)
            {
                return await InvokeReturnPathAsync();
            }
            return false;
        }

        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            AuthenticationProperties properties = null;

            try
            {
                IReadableStringCollection query = Request.Query;

                properties = UnpackStateParameter(query);
                if (properties == null)
                {
                    _logger.WriteWarning("Invalid return state");
                    return null;
                }

                // Anti-CSRF
                if (!ValidateCorrelationId(properties, _logger))
                {
                    return new AuthenticationTicket(null, properties);
                }

                Message message = await ParseRequestMessageAsync(query);

                bool messageValidated = false;

                Property mode;
                if (!message.Properties.TryGetValue("mode.http://specs.openid.net/auth/2.0", out mode))
                {
                    _logger.WriteWarning("Missing mode parameter");
                    return new AuthenticationTicket(null, properties);
                }

                if (string.Equals("cancel", mode.Value, StringComparison.Ordinal))
                {
                    _logger.WriteWarning("User cancelled signin request");
                    return new AuthenticationTicket(null, properties);
                }

                if (string.Equals("id_res", mode.Value, StringComparison.Ordinal))
                {
                    mode.Value = "check_authentication";

                    var requestBody = new FormUrlEncodedContent(message.ToFormValues());
                    HttpResponseMessage response = await _httpClient.PostAsync("https://www.google.com/accounts/o8/ud", requestBody, Request.CallCancelled);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var verifyBody = new Dictionary<string, string[]>();
                    foreach (var line in responseBody.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        int delimiter = line.IndexOf(':');
                        if (delimiter != -1)
                        {
                            verifyBody.Add("openid." + line.Substring(0, delimiter), new[] { line.Substring(delimiter + 1) });
                        }
                    }
                    var verifyMessage = new Message(new ReadableStringCollection(verifyBody), strict: false);
                    Property isValid;
                    if (verifyMessage.Properties.TryGetValue("is_valid.http://specs.openid.net/auth/2.0", out isValid))
                    {
                        if (string.Equals("true", isValid.Value, StringComparison.Ordinal))
                        {
                            messageValidated = true;
                        }
                        else
                        {
                            messageValidated = false;
                        }
                    }
                }

                // http://openid.net/specs/openid-authentication-2_0.html#verify_return_to
                // To verify that the "openid.return_to" URL matches the URL that is processing this assertion:
                // * The URL scheme, authority, and path MUST be the same between the two URLs.
                // * Any query parameters that are present in the "openid.return_to" URL MUST also
                //   be present with the same values in the URL of the HTTP request the RP received.
                if (messageValidated)
                {
                    // locate the required return_to parameter
                    string actualReturnTo;
                    if (!message.TryGetValue("return_to.http://specs.openid.net/auth/2.0", out actualReturnTo))
                    {
                        _logger.WriteWarning("openid.return_to parameter missing at return address");
                        messageValidated = false;
                    }
                    else
                    {
                        // create the expected return_to parameter based on the URL that is processing 
                        // the assertion, plus exactly and only the the query string parameter (state)
                        // that this RP must have received
                        string expectedReturnTo = BuildReturnTo(GetStateParameter(query));

                        if (!string.Equals(actualReturnTo, expectedReturnTo, StringComparison.Ordinal))
                        {
                            _logger.WriteWarning("openid.return_to parameter not equal to expected value based on return address");
                            messageValidated = false;
                        }
                    }
                }

                if (messageValidated)
                {
                    IDictionary<string, string> attributeExchangeProperties = new Dictionary<string, string>();
                    foreach (var typeProperty in message.Properties.Values)
                    {
                        if (typeProperty.Namespace == "http://openid.net/srv/ax/1.0" &&
                            typeProperty.Name.StartsWith("type."))
                        {
                            string qname = "value." + typeProperty.Name.Substring("type.".Length) + "http://openid.net/srv/ax/1.0";
                            Property valueProperty;
                            if (message.Properties.TryGetValue(qname, out valueProperty))
                            {
                                attributeExchangeProperties.Add(typeProperty.Value, valueProperty.Value);
                            }
                        }
                    }

                    var responseNamespaces = new object[]
                    {
                        new XAttribute(XNamespace.Xmlns + "openid", "http://specs.openid.net/auth/2.0"),
                        new XAttribute(XNamespace.Xmlns + "openid.ax", "http://openid.net/srv/ax/1.0")
                    };

                    IEnumerable<object> responseProperties = message.Properties
                                                                    .Where(p => p.Value.Namespace != null)
                                                                    .Select(p => (object)new XElement(XName.Get(p.Value.Name.Substring(0, p.Value.Name.Length - 1), p.Value.Namespace), p.Value.Value));

                    var responseMessage = new XElement("response", responseNamespaces.Concat(responseProperties).ToArray());

                    var identity = new ClaimsIdentity(Options.AuthenticationType);
                    XElement claimedId = responseMessage.Element(XName.Get("claimed_id", "http://specs.openid.net/auth/2.0"));
                    if (claimedId != null)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, claimedId.Value, "http://www.w3.org/2001/XMLSchema#string", Options.AuthenticationType));
                    }

                    string firstValue;
                    if (attributeExchangeProperties.TryGetValue("http://axschema.org/namePerson/first", out firstValue))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.GivenName, firstValue, "http://www.w3.org/2001/XMLSchema#string", Options.AuthenticationType));
                    }
                    string lastValue;
                    if (attributeExchangeProperties.TryGetValue("http://axschema.org/namePerson/last", out lastValue))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Surname, lastValue, "http://www.w3.org/2001/XMLSchema#string", Options.AuthenticationType));
                    }
                    string nameValue;
                    if (attributeExchangeProperties.TryGetValue("http://axschema.org/namePerson", out nameValue))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Name, nameValue, "http://www.w3.org/2001/XMLSchema#string", Options.AuthenticationType));
                    }
                    else if (!string.IsNullOrEmpty(firstValue) && !string.IsNullOrEmpty(lastValue))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Name, firstValue + " " + lastValue, "http://www.w3.org/2001/XMLSchema#string", Options.AuthenticationType));
                    }
                    else if (!string.IsNullOrEmpty(firstValue))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Name, firstValue, "http://www.w3.org/2001/XMLSchema#string", Options.AuthenticationType));
                    }
                    else if (!string.IsNullOrEmpty(lastValue))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Name, lastValue, "http://www.w3.org/2001/XMLSchema#string", Options.AuthenticationType));
                    }
                    string emailValue;
                    if (attributeExchangeProperties.TryGetValue("http://axschema.org/contact/email", out emailValue))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Email, emailValue, "http://www.w3.org/2001/XMLSchema#string", Options.AuthenticationType));
                    }

                    var context = new GoogleAuthenticatedContext(
                        Context,
                        identity,
                        properties,
                        responseMessage,
                        attributeExchangeProperties);

                    await Options.Provider.Authenticated(context);

                    return new AuthenticationTicket(context.Identity, context.Properties);
                }

                return new AuthenticationTicket(null, properties);
            }
            catch (Exception ex)
            {
                _logger.WriteError("Authentication failed", ex);
                return new AuthenticationTicket(null, properties);
            }
        }

        private static string GetStateParameter(IReadableStringCollection query)
        {
            IList<string> values = query.GetValues("state");
            if (values != null && values.Count == 1)
            {
                return values[0];
            }
            return null;
        }

        private AuthenticationProperties UnpackStateParameter(IReadableStringCollection query)
        {
            string state = GetStateParameter(query);
            if (state != null)
            {
                return Options.StateDataFormat.Unprotect(state);
            }
            return null;
        }

        private string BuildReturnTo(string state)
        {
            return Request.Scheme + "://" + Request.Host +
                RequestPathBase + Options.CallbackPath +
                "?state=" + Uri.EscapeDataString(state);
        }

        private async Task<Message> ParseRequestMessageAsync(IReadableStringCollection query)
        {
            if (Request.Method == "POST")
            {
                IFormCollection form = await Request.ReadFormAsync();
                return new Message(form, strict: true);
            }
            return new Message(query, strict: true);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "MemoryStream.Dispose is idempotent")]
        protected override Task ApplyResponseChallengeAsync()
        {
            if (Response.StatusCode != 401)
            {
                return Task.FromResult<object>(null);
            }

            AuthenticationResponseChallenge challenge = Helper.LookupChallenge(Options.AuthenticationType, Options.AuthenticationMode);

            if (challenge != null)
            {
                string requestPrefix = Request.Scheme + Uri.SchemeDelimiter + Request.Host;

                var state = challenge.Properties;
                if (String.IsNullOrEmpty(state.RedirectUri))
                {
                    state.RedirectUri = requestPrefix + Request.PathBase + Request.Path + Request.QueryString;
                }

                // Anti-CSRF
                GenerateCorrelationId(state);

                string returnTo = BuildReturnTo(Options.StateDataFormat.Protect(state));

                string authorizationEndpoint =
                    "https://www.google.com/accounts/o8/ud" +
                        "?openid.ns=" + Uri.EscapeDataString("http://specs.openid.net/auth/2.0") +
                        "&openid.ns.ax=" + Uri.EscapeDataString("http://openid.net/srv/ax/1.0") +
                        "&openid.mode=" + Uri.EscapeDataString("checkid_setup") +
                        "&openid.claimed_id=" + Uri.EscapeDataString("http://specs.openid.net/auth/2.0/identifier_select") +
                        "&openid.identity=" + Uri.EscapeDataString("http://specs.openid.net/auth/2.0/identifier_select") +
                        "&openid.return_to=" + Uri.EscapeDataString(returnTo) +
                        "&openid.realm=" + Uri.EscapeDataString(requestPrefix) +
                        "&openid.ax.mode=" + Uri.EscapeDataString("fetch_request") +
                        "&openid.ax.type.email=" + Uri.EscapeDataString("http://axschema.org/contact/email") +
                        "&openid.ax.type.name=" + Uri.EscapeDataString("http://axschema.org/namePerson") +
                        "&openid.ax.type.first=" + Uri.EscapeDataString("http://axschema.org/namePerson/first") +
                        "&openid.ax.type.last=" + Uri.EscapeDataString("http://axschema.org/namePerson/last") +
                        "&openid.ax.required=" + Uri.EscapeDataString("email,name,first,last");

                var redirectContext = new GoogleApplyRedirectContext(
                    Context, Options,
                    state, authorizationEndpoint);
                Options.Provider.ApplyRedirect(redirectContext);
            }

            return Task.FromResult<object>(null);
        }

        public async Task<bool> InvokeReturnPathAsync()
        {
            AuthenticationTicket model = await AuthenticateAsync();
            if (model == null)
            {
                _logger.WriteWarning("Invalid return state, unable to redirect.");
                Response.StatusCode = 500;
                return true;
            }

            var context = new GoogleReturnEndpointContext(Context, model);
            context.SignInAsAuthenticationType = Options.SignInAsAuthenticationType;
            context.RedirectUri = model.Properties.RedirectUri;
            model.Properties.RedirectUri = null;

            await Options.Provider.ReturnEndpoint(context);

            if (context.SignInAsAuthenticationType != null && context.Identity != null)
            {
                ClaimsIdentity signInIdentity = context.Identity;
                if (!string.Equals(signInIdentity.AuthenticationType, context.SignInAsAuthenticationType, StringComparison.Ordinal))
                {
                    signInIdentity = new ClaimsIdentity(signInIdentity.Claims, context.SignInAsAuthenticationType, signInIdentity.NameClaimType, signInIdentity.RoleClaimType);
                }
                Context.Authentication.SignIn(context.Properties, signInIdentity);
            }

            if (!context.IsRequestCompleted && context.RedirectUri != null)
            {
                if (context.Identity == null)
                {
                    // add a redirect hint that sign-in failed in some way
                    context.RedirectUri = WebUtilities.AddQueryString(context.RedirectUri, "error", "access_denied");
                }
                Response.Redirect(context.RedirectUri);
                context.RequestCompleted();
            }

            return context.IsRequestCompleted;
        }
    }
}
#pragma warning restore 618