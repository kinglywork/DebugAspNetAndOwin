﻿// <copyright file="TestPageExtensions.cs" company="Microsoft Open Technologies, Inc.">
// Copyright 2011-2013 Microsoft Open Technologies, Inc. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

#if DEBUG
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;

namespace Owin
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    /// <summary>
    /// IAppBuilder extensions for the DiagnosticsPageMiddleware.
    /// </summary>
    public static class DiagnosticsPageExtensions
    {
        /// <summary>
        /// Adds the DiagnosticsPageMiddleware to the pipeline with the given options.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IAppBuilder UseDiagnosticsPage(this IAppBuilder builder, DiagnosticsPageOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            return builder.Use(typeof(DiagnosticsPageMiddleware), options);
        }

        /// <summary>
        /// Adds the DiagnosticsPageMiddleware to the pipeline with the given path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IAppBuilder UseDiagnosticsPage(this IAppBuilder builder, PathString path)
        {
            return UseDiagnosticsPage(builder, new DiagnosticsPageOptions { Path = path });
        }

        /// <summary>
        /// Adds the DiagnosticsPageMiddleware to the pipeline.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IAppBuilder UseDiagnosticsPage(this IAppBuilder builder)
        {
            return UseDiagnosticsPage(builder, new DiagnosticsPageOptions());
        }
    }
}
#endif