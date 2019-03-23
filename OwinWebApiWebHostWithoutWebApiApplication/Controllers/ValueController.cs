using System.Web.Http;

namespace OwinWebApiWebHostWithoutWebApiApplication.Controllers
{
    public class ValueController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            return "Hello world";
        }
    }
}