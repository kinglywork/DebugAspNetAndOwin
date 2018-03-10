using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace OAuthServer.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager Authentication => HttpContext.GetOwinContext().Authentication;

        public ActionResult Login()
        {
            if (Request.HttpMethod != "POST")
            {
                return View();
            }

            var isPersistent = !string.IsNullOrEmpty(Request.Form.Get("isPersistent"));

            if (!string.IsNullOrEmpty(Request.Form.Get("submit.Signin")))
            {
                Authentication.SignIn(
                    new AuthenticationProperties { IsPersistent = isPersistent },
                    new ClaimsIdentity(new[] { new Claim(ClaimsIdentity.DefaultNameClaimType, Request.Form["username"]) }, "Application"));
            }

            return View();
        }

        public ActionResult Logout()
        {
            Authentication.SignOut(new AuthenticationProperties(), "Application");
            return View();
        }

        public ActionResult External()
        {
            if (Request.HttpMethod == "POST")
            {
                foreach (var key in Request.Form.AllKeys)
                {
                    if (!key.StartsWith("submit.External.") || string.IsNullOrEmpty(Request.Form.Get(key)))
                    {
                        continue;
                    }
                    var authType = key.Substring("submit.External.".Length);
                    Authentication.Challenge(authType);
                    return new HttpUnauthorizedResult();
                }
            }
            var identity = Authentication.AuthenticateAsync("External").Result.Identity;
            if (identity == null)
            {
                return View();
            }
            Authentication.SignOut("External");
            Authentication.SignIn(
                new AuthenticationProperties { IsPersistent = true },
                new ClaimsIdentity(identity.Claims, "Application", identity.NameClaimType, identity.RoleClaimType));
            return Redirect(Request.QueryString["ReturnUrl"]);
        }
    }
}