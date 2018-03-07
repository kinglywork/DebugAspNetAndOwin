// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.Cookies
{
    /// <summary>
    /// This default implementation of the ICookieAuthenticationProvider may be used if the
    /// application only needs to override a few of the interface methods. This may be used as a base class
    /// or may be instantiated directly.
    /// </summary>
    public class CookieAuthenticationProvider : ICookieAuthenticationProvider
    {
        /// <summary>
        /// Create a new instance of the default provider.
        /// </summary>
        public CookieAuthenticationProvider()
        {
            OnValidateIdentity = context => Task.FromResult<object>(null);
            OnResponseSignIn = context => { };
            OnResponseSignedIn = context => { };
            OnResponseSignOut = context => { };
            OnApplyRedirect = DefaultBehavior.ApplyRedirect;
            OnException = context => { };
        }

        /// <summary>
        /// A delegate assigned to this property will be invoked when the related method is called
        /// </summary>
        public Func<CookieValidateIdentityContext, Task> OnValidateIdentity { get; set; }

        /// <summary>
        /// A delegate assigned to this property will be invoked when the related method is called
        /// </summary>
        public Action<CookieResponseSignInContext> OnResponseSignIn { get; set; }

        /// <summary>
        /// A delegate assigned to this property will be invoked when the related method is called
        /// </summary>
        public Action<CookieResponseSignedInContext> OnResponseSignedIn { get; set; }

        /// <summary>
        /// A delegate assigned to this property will be invoked when the related method is called
        /// </summary>
        public Action<CookieResponseSignOutContext> OnResponseSignOut { get; set; }

        /// <summary>
        /// A delegate assigned to this property will be invoked when the related method is called
        /// </summary>
        public Action<CookieApplyRedirectContext> OnApplyRedirect { get; set; }

        /// <summary>
        /// A delegate assigned to this property will be invoked when the related method is called
        /// </summary>
        public Action<CookieExceptionContext> OnException { get; set; }

        /// <summary>
        /// Implements the interface method by invoking the related delegate method
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual Task ValidateIdentity(CookieValidateIdentityContext context)
        {
            return OnValidateIdentity.Invoke(context);
        }

        /// <summary>
        /// Implements the interface method by invoking the related delegate method
        /// </summary>
        /// <param name="context"></param>
        public virtual void ResponseSignIn(CookieResponseSignInContext context)
        {
            OnResponseSignIn.Invoke(context);
        }

        /// <summary>
        /// Implements the interface method by invoking the related delegate method
        /// </summary>
        /// <param name="context"></param>
        public virtual void ResponseSignedIn(CookieResponseSignedInContext context)
        {
            OnResponseSignedIn.Invoke(context);
        }

        /// <summary>
        /// Implements the interface method by invoking the related delegate method
        /// </summary>
        /// <param name="context"></param>
        public virtual void ResponseSignOut(CookieResponseSignOutContext context)
        {
            OnResponseSignOut.Invoke(context);
        }

        /// <summary>
        /// Implements the interface method by invoking the related delegate method
        /// </summary>
        /// <param name="context">Contains information about the event</param>
        public virtual void ApplyRedirect(CookieApplyRedirectContext context)
        {
            OnApplyRedirect.Invoke(context);
        }

        /// <summary>
        /// Implements the interface method by invoking the related delegate method
        /// </summary>
        /// <param name="context">Contains information about the event</param>
        public virtual void Exception(CookieExceptionContext context)
        {
            OnException.Invoke(context);
        }
    }
}
