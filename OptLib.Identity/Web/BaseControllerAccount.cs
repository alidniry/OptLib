using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OptLib.Identity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OptLib.Identity.Web
{
    public abstract class BaseControllerAccount<TUser, TRole, TAppUserManager, TAppRoleManager, TAppSignInManager> 
        : BaseControllerIdentity<TUser, TRole, TAppUserManager, TAppRoleManager, TAppSignInManager>
        where TUser : class, IUser<string>
        where TRole : class, IRole<string>
        where TAppUserManager : UserManager<TUser, string>
        where TAppRoleManager : RoleManager<TRole, string>
        where TAppSignInManager : SignInManager<TUser, string>
    {
        //private TApplicationSignInManager _signInManager;
        //private TApplicationUserManager _userManager;

        //public ApplicationSignInManager SignInManager { get; set; }
        //public ApplicationUserManager UserManager { get; set; }

        public BaseControllerAccount()
            : base()
        {
        }

        public BaseControllerAccount(TAppUserManager userManager, TAppRoleManager roleManager, TAppSignInManager signInManager, IAuthenticationManager authManager)
            : base(userManager, roleManager, signInManager, authManager)
        {

        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            //SignInManager = HttpContext.GetOwinContext().Get<TApplicationSignInManager>();
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}