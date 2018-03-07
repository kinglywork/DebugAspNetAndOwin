using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

namespace OwinApp
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