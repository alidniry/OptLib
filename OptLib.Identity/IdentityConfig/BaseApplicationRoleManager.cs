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
    public class BaseApplicationRoleManager<TRole>
        : RoleManager<TRole>
        where TRole : class, IRole<string>
    {
        public BaseApplicationRoleManager(
            IRoleStore<TRole, string> roleStore)
            : base(roleStore)
        {
        }

    }
}
