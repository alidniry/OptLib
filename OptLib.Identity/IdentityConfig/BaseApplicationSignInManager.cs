using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using OptLib.Identity.Models;

namespace OptLib.Identity
{
    // Configure the application sign-in manager which is used in this application.
    public class BaseApplicationSignInManager<TUser>
        : SignInManager<TUser, string>
        where TUser : class, IUser<string>
    {
        public BaseApplicationSignInManager(UserManager<TUser, string> userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        //public virtual override Task<ClaimsIdentity> CreateUserIdentityAsync(TUser user)
        //{
        //    return base.CreateUserIdentityAsync(user);
        //}

    }
}
