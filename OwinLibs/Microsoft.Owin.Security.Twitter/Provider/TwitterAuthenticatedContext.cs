﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Security.Claims;
using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.Twitter
{
    /// <summary>
    /// Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.
    /// </summary>
    public class TwitterAuthenticatedContext : BaseContext
    {
        /// <summary>
        /// Initializes a <see cref="TwitterAuthenticatedContext"/>
        /// </summary>
        /// <param name="context">The OWIN environment</param>
        /// <param name="userId">Twitter user ID</param>
        /// <param name="screenName">Twitter screen name</param>
        /// <param name="accessToken">Twitter access token</param>
        /// <param name="accessTokenSecret">Twitter access token secret</param>
        public TwitterAuthenticatedContext(
            IOwinContext context,
            string userId,
            string screenName,
            string accessToken,
            string accessTokenSecret)
            : base(context)
        {
            UserId = userId;
            ScreenName = screenName;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }

        /// <summary>
        /// Gets the Twitter user ID
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// Gets the Twitter screen name
        /// </summary>
        public string ScreenName { get; private set; }

        /// <summary>
        /// Gets the Twitter access token
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets the Twitter access token secret
        /// </summary>
        public string AccessTokenSecret { get; private set; }

        /// <summary>
        /// Gets the <see cref="ClaimsIdentity"/> representing the user
        /// </summary>
        public ClaimsIdentity Identity { get; set; }

        /// <summary>
        /// Gets or sets a property bag for common authentication properties
        /// </summary>
        public AuthenticationProperties Properties { get; set; }
    }
}
