using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace OptLib.Identity.Models
{
    public abstract class BaseApplicationRole 
        : IdentityRole
    {
        public BaseApplicationRole() 
            : base()
        {

        }
        public BaseApplicationRole(string name) 
            : base(name)
        {

        }

        //Any relevant properties
        public string Description { get; set; }
        public string MenuIcon { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}