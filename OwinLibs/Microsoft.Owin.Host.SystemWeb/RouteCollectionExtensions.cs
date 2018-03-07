﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.Owin.Host.SystemWeb;
using Owin;

namespace System.Web.Routing
{
    /// <summary>
    /// Provides extension methods for registering OWIN applications as System.Web routes.
    /// </summary>
    public static class RouteCollectionExtensions
    {
        /// <summary>
        /// Registers a route for the default OWIN application.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="pathBase">The route path to map to the default OWIN application.</param>
        /// <returns>The created route.</returns>
        public static RouteBase MapOwinPath(this RouteCollection routes, string pathBase)
        {
            return Add(routes, null, new OwinRoute(pathBase, OwinApplication.Accessor));
        }

        /// <summary>
        /// Registers a route for a specific OWIN application entry point.
        /// </summary>
        /// <typeparam name="TApp">The OWIN application entry point type.</typeparam>
        /// <param name="routes">The route collection.</param>
        /// <param name="pathBase">The route path to map to the given OWIN application.</param>
        /// <param name="app">The OWIN application entry point.</param>
        /// <returns>The created route.</returns>
        public static RouteBase MapOwinPath<TApp>(this RouteCollection routes, string pathBase, TApp app)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            OwinAppContext appDelegate = OwinBuilder.Build(builder => builder.Use(new Func<object, object>(_ => app)));
            return Add(routes, null, new OwinRoute(pathBase, () => appDelegate));
        }

        /// <summary>
        /// Invokes the System.Action startup delegate to build the OWIN application
        /// and then registers a route for it on the given path.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="pathBase">The route path to map to the given OWIN application.</param>
        /// <param name="startup">A System.Action delegate invoked to build the OWIN application.</param>
        /// <returns>The created route.</returns>
        public static RouteBase MapOwinPath(this RouteCollection routes, string pathBase, Action<IAppBuilder> startup)
        {
            OwinAppContext appDelegate = OwinBuilder.Build(startup);
            return Add(routes, null, new OwinRoute(pathBase, () => appDelegate));
        }

        /// <summary>
        /// Registers a route for the default OWIN application.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="name">The given name of the route.</param>
        /// <param name="pathBase">The route path to map to the default OWIN application.</param>
        /// <returns>The created route.</returns>
        public static RouteBase MapOwinPath(this RouteCollection routes, string name, string pathBase)
        {
            return Add(routes, name, new OwinRoute(pathBase, OwinApplication.Accessor));
        }

        /// <summary>
        /// Registers a route for a specific OWIN application entry point.
        /// </summary>
        /// <typeparam name="TApp">The OWIN application entry point type.</typeparam>
        /// <param name="routes">The route collection.</param>
        /// <param name="name">The given name of the route.</param>
        /// <param name="pathBase">The route path to map to the given OWIN application.</param>
        /// <param name="app">The OWIN application entry point.</param>
        /// <returns>The created route.</returns>
        public static RouteBase MapOwinPath<TApp>(this RouteCollection routes, string name, string pathBase, TApp app)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            OwinAppContext appDelegate = OwinBuilder.Build(builder => builder.Use(new Func<object, object>(_ => app)));
            return Add(routes, name, new OwinRoute(pathBase, () => appDelegate));
        }

        /// <summary>
        /// Invokes the System.Action startup delegate to build the OWIN application
        /// and then registers a route for it on the given path.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="name">The given name of the route.</param>
        /// <param name="pathBase">The route path to map to the given OWIN application.</param>
        /// <param name="startup">A System.Action delegate invoked to build the OWIN application.</param>
        /// <returns>The created route.</returns>
        public static RouteBase MapOwinPath(this RouteCollection routes, string name, string pathBase, Action<IAppBuilder> startup)
        {
            OwinAppContext appDelegate = OwinBuilder.Build(startup);
            return Add(routes, name, new OwinRoute(pathBase, () => appDelegate));
        }

        /// <summary>
        /// Provides a way to define routes for an OWIN pipeline.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="routeUrl">The URL pattern for the route.</param>
        /// <param name="startup">The method to initialize the pipeline that processes requests for the route.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "Parameter type determined by Route class")]
        public static Route MapOwinRoute(
            this RouteCollection routes,
            string routeUrl,
            Action<IAppBuilder> startup)
        {
            return Add(routes, null, new Route(routeUrl, new OwinRouteHandler(startup)));
        }

        /// <summary>
        /// Provides a way to define routes for an OWIN pipeline.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="routeUrl">The URL pattern for the route.</param>
        /// <param name="defaults">The values to use if the URL does not contain all the parameters.</param>
        /// <param name="startup">The method to initialize the pipeline that processes requests for the route.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "Parameter type determined by Route class")]
        public static Route MapOwinRoute(
            this RouteCollection routes,
            string routeUrl,
            RouteValueDictionary defaults,
            Action<IAppBuilder> startup)
        {
            return Add(routes, null, new Route(routeUrl, defaults, new OwinRouteHandler(startup)));
        }

        /// <summary>
        /// Provides a way to define routes for an OWIN pipeline.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="routeUrl">The URL pattern for the route.</param>
        /// <param name="defaults">The values to use if the URL does not contain all the parameters.</param>
        /// <param name="constraints">A regular expression that specifies valid values for a URL parameter.</param>
        /// <param name="startup">The method to initialize the pipeline that processes requests for the route.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "Parameter type determined by Route class")]
        public static Route MapOwinRoute(
            this RouteCollection routes,
            string routeUrl,
            RouteValueDictionary defaults,
            RouteValueDictionary constraints,
            Action<IAppBuilder> startup)
        {
            return Add(routes, null, new Route(routeUrl, defaults, constraints, new OwinRouteHandler(startup)));
        }

        /// <summary>
        /// Provides a way to define routes for an OWIN pipeline.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="routeUrl">The URL pattern for the route.</param>
        /// <param name="defaults">The values to use if the URL does not contain all the parameters.</param>
        /// <param name="constraints">A regular expression that specifies valid values for a URL parameter.</param>
        /// <param name="dataTokens">Custom values that are passed to the route handler, but which are not used to determine whether the route matches a specific URL pattern. These values are passed to the route handler, where they can be used for processing the request.</param>
        /// <param name="startup">The method to initialize the pipeline that processes requests for the route.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "Parameter type determined by Route class")]
        public static Route MapOwinRoute(
            this RouteCollection routes,
            string routeUrl,
            RouteValueDictionary defaults,
            RouteValueDictionary constraints,
            RouteValueDictionary dataTokens,
            Action<IAppBuilder> startup)
        {
            return Add(routes, null, new Route(routeUrl, defaults, constraints, dataTokens, new OwinRouteHandler(startup)));
        }

        /// <summary>
        /// Provides a way to define routes for an OWIN pipeline.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="routeName">The name of the route.</param>
        /// <param name="routeUrl">The URL pattern for the route.</param>
        /// <param name="startup">The method to initialize the pipeline that processes requests for the route.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#", Justification = "Parameter type determined by Route class")]
        public static Route MapOwinRoute(
            this RouteCollection routes,
            string routeName,
            string routeUrl,
            Action<IAppBuilder> startup)
        {
            return Add(routes, routeName, new Route(routeUrl, new OwinRouteHandler(startup)));
        }

        /// <summary>
        /// Provides a way to define routes for an OWIN pipeline.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="routeName">The name of the route.</param>
        /// <param name="routeUrl">The URL pattern for the route.</param>
        /// <param name="defaults">The values to use if the URL does not contain all the parameters.</param>
        /// <param name="startup">The method to initialize the pipeline that processes requests for the route.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#", Justification = "Parameter type determined by Route class")]
        public static Route MapOwinRoute(
            this RouteCollection routes,
            string routeName,
            string routeUrl,
            RouteValueDictionary defaults,
            Action<IAppBuilder> startup)
        {
            return Add(routes, routeName, new Route(routeUrl, defaults, new OwinRouteHandler(startup)));
        }

        /// <summary>
        /// Provides a way to define routes for an OWIN pipeline.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="routeName">The name of the route.</param>
        /// <param name="routeUrl">The URL pattern for the route.</param>
        /// <param name="defaults">The values to use if the URL does not contain all the parameters.</param>
        /// <param name="constraints">A regular expression that specifies valid values for a URL parameter.</param>
        /// <param name="startup">The method to initialize the pipeline that processes requests for the route.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#", Justification = "Parameter type determined by Route class")]
        public static Route MapOwinRoute(
            this RouteCollection routes,
            string routeName,
            string routeUrl,
            RouteValueDictionary defaults,
            RouteValueDictionary constraints,
            Action<IAppBuilder> startup)
        {
            return Add(routes, routeName, new Route(routeUrl, defaults, constraints, new OwinRouteHandler(startup)));
        }

        /// <summary>
        /// Provides a way to define routes for an OWIN pipeline.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="routeName">The name of the route.</param>
        /// <param name="routeUrl">The URL pattern for the route.</param>
        /// <param name="defaults">The values to use if the URL does not contain all the parameters.</param>
        /// <param name="constraints">A regular expression that specifies valid values for a URL parameter.</param>
        /// <param name="dataTokens">Custom values that are passed to the route handler, but which are not used to determine whether the route matches a specific URL pattern. These values are passed to the route handler, where they can be used for processing the request.</param>
        /// <param name="startup">The method to initialize the pipeline that processes requests for the route.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#", Justification = "Parameter type determined by Route class")]
        public static Route MapOwinRoute(
            this RouteCollection routes,
            string routeName,
            string routeUrl,
            RouteValueDictionary defaults,
            RouteValueDictionary constraints,
            RouteValueDictionary dataTokens,
            Action<IAppBuilder> startup)
        {
            return Add(routes, routeName, new Route(routeUrl, defaults, constraints, dataTokens, new OwinRouteHandler(startup)));
        }

        private static T Add<T>(RouteCollection routes, string name, T item) where T : RouteBase
        {
            if (string.IsNullOrEmpty(name))
            {
                routes.Add(item);
            }
            else
            {
                routes.Add(name, item);
            }
            return item;
        }
    }
}
