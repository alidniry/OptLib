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
    public class BaseApplicationSignInManager<TUser, TKey>
        : SignInManager<TUser, TKey>
        where TUser : class, IUser<TKey>
        where TKey : IEquatable<TKey>
    {
        public BaseApplicationSignInManager(UserManager<TUser, TKey> userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        //public virtual override Task<ClaimsIdentity> CreateUserIdentityAsync(TUser user)
        //{
        //    return base.CreateUserIdentityAsync(user);
        //}

    }
}
