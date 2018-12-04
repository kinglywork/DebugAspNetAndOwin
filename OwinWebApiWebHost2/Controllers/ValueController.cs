using System.Collections.Generic;
using System.Web.Http;

namespace OwinWebApiWebHost2.Controllers
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