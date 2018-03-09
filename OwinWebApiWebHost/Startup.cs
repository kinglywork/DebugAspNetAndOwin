using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DebugWebApiAndOwin.Startup))]
namespace DebugWebApiAndOwin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await next.Invoke();
            });
        }
    }
}