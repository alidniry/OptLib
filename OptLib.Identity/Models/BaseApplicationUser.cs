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
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class BaseApplicationUser
        : IdentityUser
    {
        public BaseApplicationUser()
            : base()
        {

        }
        public BaseApplicationUser(string username, string name)
            : base(username)
        {
            this.Name = name;
        }
        [Required]
        [StringLength(50)]
        [Column(Order = 2, TypeName = "nvarchar")]
        public String Name { get; set; }
    }
}