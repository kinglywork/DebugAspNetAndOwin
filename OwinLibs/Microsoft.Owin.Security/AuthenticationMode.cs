// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.Owin.Security
{
    /// <summary>
    /// Controls the behavior of authentication middleware
    /// </summary>
    public enum AuthenticationMode
    {
        /// <summary>
        /// In Active mode the authentication middleware will alter the user identity as the request arrives, and
        /// will also alter a plain 401 as the response leaves.
        /// </summary>
        Active,

        /// <summary>
        /// In Passive mode the authentication middleware will only provide user identity when asked, and will only
        /// alter 401 responses where the authentication type named in the extra challenge data.
        /// </summary>
        Passive
    }
}
