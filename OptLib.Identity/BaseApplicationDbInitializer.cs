using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OptLib.Identity.Models;

namespace OptLib.Identity
{
    public class ApplicationDbInitializer
        : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
            InitializeIdentityForEF(context);
        }
        public static dynamic RoleCreate(ApplicationRoleManager roleManager, ApplicationRole appRole)
        {
            //Thread.Sleep(10000);
            if (appRole != null && roleManager.FindByName(appRole.Name) == null)
                return roleManager.Create(appRole);
            return null;
        }
        public static ApplicationUser UserCreate(ApplicationUserManager userManager, string username, string password, string name, string email
            /*, string name2, string password2*/)
        {
            var user = userManager.FindByName(username);
            if (user == null)
            {
                user = new ApplicationUser(username, name) { Email = email };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }
            return user;
        }
        public static IdentityResult UserAddRole<TUser, TKey>(UserManager<TUser, TKey> manager, TKey userId, params string[] role)
            where TUser : class, IUser<TKey>
            where TKey : IEquatable<TKey>
        {
            foreach (var item in role)
            {
                var rolesForUser = manager.GetRoles(userId);
                //if (!rolesForUser.Contains((string)item.Name))
                if (!rolesForUser.Contains(item))
                {
                    var result = manager.AddToRole(userId, item);
                }
            }
            return null;
        }
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var users = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            var roleSystem = RoleCreate(roles, new ApplicationRole("SYSTEMS") { Description = "کاربر سیستم" });
            var roleAdmin = RoleCreate(roles, new ApplicationRole("ADMINS") { Description = "کاربران راهبر" });
            var roleManager = RoleCreate(roles, new ApplicationRole("MANAGERS") { Description = "کاربران مدیر" });
            var rolePersonal = RoleCreate(roles, new ApplicationRole("PERSONALS") { Description = "کارمندان" });
            var roleGuset = RoleCreate(roles, new ApplicationRole("GUSETS") { Description = "کاربران میهمان" });

            var user_system = UserCreate(users, "system", "Aa@20551", "سیستم", "system@gmail.com");
            var user_guset = UserCreate(users, "guset", "Aa@20551", "کاربر میهمان", "guset@gmail.com");
            var user_root = UserCreate(users, "root", "Aa@20551", "کاربر اصلی", "root@gmail.com");
            var user_alidniry1 = UserCreate(users, "alidniry1", "Aa@20551", "علی دهقان", "ali.dniry1@gmail.com");
            var user_alidniry2 = UserCreate(users, "alidniry2", "Aa@20551", "علی دهقان نیری", "ali.dniry2@gmail.com");

            IdentityResult result = null;
            result = UserAddRole(users, user_system.Id, "SYSTEMS");
            result = UserAddRole(users, user_root.Id, "ADMINS", "MANAGERS", "PERSONALS");
            result = UserAddRole(users, user_alidniry1.Id, "MANAGERS", "PERSONALS");
            result = UserAddRole(users, user_alidniry2.Id, "PERSONALS");
            result = UserAddRole(users, user_guset.Id, "GUSETS");

        }
    }
}