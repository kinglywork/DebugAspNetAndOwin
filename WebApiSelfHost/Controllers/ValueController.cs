using System.Web.Http;

namespace OwinWebApiSelfHost.Controllers
{
    public class ValueController : ApiController
    {
        public string Get()
        {
            return "Hello Asp.Net WebAPI with SelfHost";
        }
    }
}
