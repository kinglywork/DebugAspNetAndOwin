﻿using System;
using System.Web.Http;
using Owin;

namespace OwinWebApiSelfHost
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.Use(async (context, next) =>
            {
                Console.WriteLine(@"before enter webapi pipeline");
                await next.Invoke();
                Console.WriteLine(@"after go out of webapi pipeline");
            });

            appBuilder.UseWebApi(config);

            appBuilder.Use(async (context, next) =>
            {
                Console.WriteLine(@"next middleware of webapi");
                await next.Invoke();
            });
        }
    }
}
