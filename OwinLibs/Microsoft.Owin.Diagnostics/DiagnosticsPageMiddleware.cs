﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

#if DEBUG
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin.Diagnostics.Views;

namespace Microsoft.Owin.Diagnostics
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    /// <summary>
    /// A human readable page with basic debugging actions.
    /// </summary>
    public class DiagnosticsPageMiddleware
    {
        private readonly AppFunc _next;
        private readonly DiagnosticsPageOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticsPageMiddleware"/> class
        /// </summary>
        /// <param name="next"></param>
        /// <param name="options"></param>
        public DiagnosticsPageMiddleware(AppFunc next, DiagnosticsPageOptions options)
        {
            _next = next;
            _options = options;
        }

        /// <summary>
        /// Process an individual request.
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        public Task Invoke(IDictionary<string, object> environment)
        {
            IOwinContext context = new OwinContext(environment);

            if (!_options.Path.HasValue || _options.Path == context.Request.Path)
            {
                var page = new DiagnosticsPage();
                page.Execute(context);
                return Task.FromResult(0);
            }
            return _next(environment);
        }
    }
}
#endif