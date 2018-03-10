using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace OAuthServer.Controllers
{
    public class OAuthController : Controller
    {
        private IAuthenticationManager Authentication => HttpContext.GetOwinContext().Authentication;

        public ActionResult Authorize()
        {
            if (Response.StatusCode != 200)
            {
                return View("AuthorizeError");
            }
            
            var ticket = Authentication.AuthenticateAsync("Application").Result;
            var identity = ticket?.Identity;
            if (identity == null)
            {
                Authentication.Challenge("Application");
                return new HttpUnauthorizedResult();
            }

            var scopes = (Request.QueryString.Get("scope") ?? "").Split(' ');

            if (Request.HttpMethod != "POST")
            {
                return View();
            }

            if (!string.IsNullOrEmpty(Request.Form.Get("submit.Grant")))
            {
                identity = new ClaimsIdentity(identity.Claims, "Bearer", identity.NameClaimType, identity.RoleClaimType);
                foreach (var scope in scopes)
                {
                    identity.AddClaim(new Claim("urn:oauth:scope", scope));
                }
                Authentication.SignIn(identity);
            }
            if (!string.IsNullOrEmpty(Request.Form.Get("submit.Login")))
            {
                Authentication.SignOut("Application");
                Authentication.Challenge("Application");
                return new HttpUnauthorizedResult();
            }

            return View();
        }
    }
}