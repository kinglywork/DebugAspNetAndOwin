using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DebugAspNetWebApiSelfHost.Controllers
{
    public class ValueController : ApiController
    {
        public string Get()
        {
            return "Hello Asp.Net WebAPI with SelfHost";
        }
    }
}
