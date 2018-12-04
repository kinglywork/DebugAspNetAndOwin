using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using OwinWebApiWebHost2;

[assembly: OwinStartup(typeof(Startup))]
namespace OwinWebApiWebHost2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}