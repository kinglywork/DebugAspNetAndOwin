﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace Microsoft.Owin.Security.MicrosoftAccount
{
    /// <summary>
    /// Configuration options for <see cref="MicrosoftAccountAuthenticationMiddleware"/>
    /// </summary>
    public class MicrosoftAccountAuthenticationOptions : AuthenticationOptions
    {
        /// <summary>
        /// Initializes a new <see cref="MicrosoftAccountAuthenticationOptions"/>.
        /// </summary>
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
            MessageId = "Microsoft.Owin.Security.MicrosoftAccount.MicrosoftAccountAuthenticationOptions.set_Caption(System.String)", Justification = "Not localizable")]
        public MicrosoftAccountAuthenticationOptions() : base(Constants.DefaultAuthenticationType)
        {
            Caption = Constants.DefaultAuthenticationType;
            CallbackPath = new PathString("/signin-microsoft");
            AuthenticationMode = AuthenticationMode.Passive;
            Scope = new List<string>();
            BackchannelTimeout = TimeSpan.FromSeconds(60);
        }

        /// <summary>
        /// Gets or sets the a pinned certificate validator to use to validate the endpoints used
        /// in back channel communications belong to Microsoft Account.
        /// </summary>
        /// <value>
        /// The pinned certificate validator.
        /// </value>
        /// <remarks>If this property is null then the default certificate checks are performed,
        /// validating the subject name and if the signing chain is a trusted party.</remarks>
        public ICertificateValidator BackchannelCertificateValidator { get; set; }

        /// <summary>
        /// Get or sets the text that the user can display on a sign in user interface.
        /// </summary>
        /// <remarks>
        /// The default value is 'Microsoft'
        /// </remarks>
        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

        /// <summary>
        /// The application client ID assigned by the Microsoft authentication service.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The application client secret assigned by the Microsoft authentication service.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets timeout value in milliseconds for back channel communications with Microsoft.
        /// </summary>
        /// <value>
        /// The back channel timeout.
        /// </value>
        public TimeSpan BackchannelTimeout { get; set; }

        /// <summary>
        /// The HttpMessageHandler used to communicate with Microsoft.
        /// This cannot be set at the same time as BackchannelCertificateValidator unless the value 
        /// can be downcast to a WebRequestHandler.
        /// </summary>
        public HttpMessageHandler BackchannelHttpHandler { get; set; }

        /// <summary>
        /// A list of permissions to request.
        /// </summary>
        public IList<string> Scope { get; private set; }

        /// <summary>
        /// The request path within the application's base path where the user-agent will be returned.
        /// The middleware will process this request when it arrives.
        /// Default value is "/signin-microsoft".
        /// </summary>
        public PathString CallbackPath { get; set; }

        /// <summary>
        /// Gets or sets the name of another authentication middleware which will be responsible for actually issuing a user <see cref="System.Security.Claims.ClaimsIdentity"/>.
        /// </summary>
        public string SignInAsAuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IMicrosoftAccountAuthenticationProvider"/> used to handle authentication events.
        /// </summary>
        public IMicrosoftAccountAuthenticationProvider Provider { get; set; }

        /// <summary>
        /// Gets or sets the type used to secure data handled by the middleware.
        /// </summary>
        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }
    }
}
