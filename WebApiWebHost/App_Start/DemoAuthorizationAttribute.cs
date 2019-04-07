using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DebugAspNetWebApiHost
{
    public class DemoAuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var userPrinciple = actionContext.RequestContext.Principal;
            return userPrinciple != null && userPrinciple.Identity.IsAuthenticated;
        }
    }
}