﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin.Security.OpenIdConnect;

namespace Microsoft.Owin.Security.Notifications
{
    /// <summary>
    /// This Notification can be used to be informed when an 'AuthorizationCode' is received over the OpenIdConnect protocol.
    /// </summary>
    public class AuthorizationCodeReceivedNotification : BaseNotification<OpenIdConnectAuthenticationOptions>
    {
        /// <summary>
        /// Creates a <see cref="AuthorizationCodeReceivedNotification"/>
        /// </summary>
        public AuthorizationCodeReceivedNotification(IOwinContext context, OpenIdConnectAuthenticationOptions options)
            : base(context, options)
        { 
        }

        /// <summary>
        /// Gets or sets the <see cref="AuthenticationTicket"/>
        /// </summary>
        public AuthenticationTicket AuthenticationTicket { get; set; }

        /// <summary>
        /// Gets or sets the 'code'.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="JwtSecurityToken"/> that was received in the id_token + code OpenIdConnectRequest.
        /// </summary>
        public JwtSecurityToken JwtSecurityToken { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="OpenIdConnectMessage"/>.
        /// </summary>
        public OpenIdConnectMessage ProtocolMessage { get; set; }

        /// <summary>
        /// Gets or sets the 'redirect_uri'.
        /// </summary>
        /// <remarks>This is the redirect_uri that was sent in the id_token + code OpenIdConnectRequest.</remarks>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "user controlled, not necessarily a URI")]
        public string RedirectUri { get; set; }
    }
}