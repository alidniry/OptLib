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
    public abstract class BaseIdentityController<TUser, TRole, TAppUserManager, TAppRoleManager, TAppSignInManager> : Controller
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

        public BaseIdentityController()
        {
        }

        public BaseIdentityController(TAppUserManager userManager, TAppRoleManager roleManager, TAppSignInManager signInManager, IAuthenticationManager authManager)
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

    }
}