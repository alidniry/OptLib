using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OptLib.Identity.Web
{
    public abstract class BaseControllerIdentity<TUser, TRole, TAppUserManager, TAppRoleManager, TAppSignInManager> : Controller
        where TUser : class, IUser<string>
        where TRole : class, IRole<string>
        where TAppUserManager : UserManager<TUser, string>
        where TAppRoleManager : RoleManager<TRole, string>
        where TAppSignInManager : SignInManager<TUser, string>
    {
        public TAppUserManager UserManager { get; set; }
        public TAppRoleManager RoleManager { get; set; }
        public TAppSignInManager SignInManager { get; set; }
        public IAuthenticationManager AuthenticationManager { get; set; }

        public BaseControllerIdentity()
        {
        }

        public BaseControllerIdentity(TAppUserManager userManager, TAppRoleManager roleManager, TAppSignInManager signInManager, IAuthenticationManager authManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
            AuthenticationManager = authManager;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UserManager != null)
                {
                    UserManager.Dispose();
                    UserManager = null;
                }

                if (RoleManager != null)
                {
                    RoleManager.Dispose();
                    RoleManager = null;
                }

                if (SignInManager != null)
                {
                    SignInManager.Dispose();
                    SignInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home", routeValues: new { area = "" });
        }

        public class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}