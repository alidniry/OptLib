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
    public abstract class BaseController<TUser, TApplicationUserManager, TApplicationSignInManager, TKey> : Controller
        where TKey : IEquatable<TKey>
        where TUser : class, IUser<TKey>
        where TApplicationUserManager : UserManager<TUser, TKey>
        where TApplicationSignInManager : SignInManager<TUser, TKey>
    {
        public IAuthenticationManager AuthenticationManager { get; set; }
        public TApplicationSignInManager SignInManager { get; set; }
        public TApplicationUserManager UserManager { get; set; }

        //public ApplicationSignInManager SignInManager { get; set; }
        //public ApplicationUserManager UserManager { get; set; }

        public BaseController()
        {
        }

        public BaseController(TApplicationUserManager userManager, TApplicationSignInManager signInManager, IAuthenticationManager authManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            AuthenticationManager = authManager;
        }

        //public TApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<TApplicationSignInManager>();
        //    }
        //    protected set
        //    {
        //        _signInManager = value;
        //    }
        //}

        //public TApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<TApplicationUserManager>();
        //    }
        //    protected set
        //    {
        //        _userManager = value;
        //    }
        //}

        //// GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UserManager != null)
                {
                    UserManager.Dispose();
                    UserManager = null;
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

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}

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