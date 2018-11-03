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
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class BaseApplicationUserManager<TUser>
        : UserManager<TUser, string>
        where TUser : class, IUser<string>
    {
        public BaseApplicationUserManager(IUserStore<TUser> store)
            : base(store)
        {
        }

    }
}
