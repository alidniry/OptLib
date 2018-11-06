using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace OptLib.Identity.Models
{
    public class BaseApplicationUserClaim
        : IdentityUserClaim
    {
        public BaseApplicationUserClaim()
            : base()
        {

        }
    }
}