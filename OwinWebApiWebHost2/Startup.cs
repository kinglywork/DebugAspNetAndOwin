using System.Web.Http;
using Microsoft.Owin;
using Owin;
using OwinWebApiWebHostWithoutWebApiApplication;

[assembly: OwinStartup(typeof(Startup))]
namespace OwinWebApiWebHostWithoutWebApiApplication
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