using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OptLib.Identity.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace OptLib.Identity
{
    public abstract class BaseApplicationDbContext<TUser, TRole/*, TKey, TUserLogin, TUserRole, TUserClaim*/>
        : IdentityDbContext<TUser, TRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
        //where TUser : BaseApplicationUser //IdentityUser
        where TUser : IdentityUser//<string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
        where TRole : IdentityRole//<string, IdentityUserRole>
        //where TUserLogin : IdentityUserLogin<TKey>
        //where TUserRole : IdentityUserRole<TKey>
        //where TUserClaim : IdentityUserClaim<TKey>
    {
        public BaseApplicationDbContext()
            : base()
        {

        }
        public BaseApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        public BaseApplicationDbContext(DbCompiledModel model)
            : base(model)
        {

        }
        //public BaseApplicationDbContext(string nameOrConnectionString, bool throwIfV1Schema)
        //    : base(nameOrConnectionString, throwIfV1Schema)
        //{
        //}
        public BaseApplicationDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
        public BaseApplicationDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {

        }
        public BaseApplicationDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            // Keep this:
            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

            // Change TUser to ApplicationUser everywhere else - 
            // IdentityUser and ApplicationUser essentially 'share' the AspNetUsers Table in the database:
            EntityTypeConfiguration<BaseApplicationUser> table =
                modelBuilder.Entity<BaseApplicationUser>().ToTable("AspNetUsers");

            table.Property((BaseApplicationUser u) => u.UserName).IsRequired();

            // EF won't let us swap out IdentityUserRole for ApplicationUserRole here:
            modelBuilder.Entity<BaseApplicationUser>().HasMany<IdentityUserRole>((BaseApplicationUser u) => u.Roles);
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>
                new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");

            // Leave this alone:
            EntityTypeConfiguration<IdentityUserLogin> entityTypeConfiguration =
                modelBuilder.Entity<IdentityUserLogin>().HasKey((IdentityUserLogin l) =>
                    new {
                        UserId = l.UserId,
                        LoginProvider = l.LoginProvider,
                        ProviderKey
                        = l.ProviderKey
                    }).ToTable("AspNetUserLogins");

            //entityTypeConfiguration.HasRequired<IdentityUser>((IdentityUserLogin u) => u.User);
            EntityTypeConfiguration<IdentityUserClaim> table1 =
                modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");

            //table1.HasRequired<IdentityUser>((IdentityUserClaim u) => u.User);

            // Add this, so that IdentityRole can share a table with ApplicationRole:
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");

            // Change these from IdentityRole to ApplicationRole:
            EntityTypeConfiguration<BaseApplicationRole> entityTypeConfiguration1 =
                modelBuilder.Entity<BaseApplicationRole>().ToTable("AspNetRoles");

            entityTypeConfiguration1.Property((BaseApplicationRole r) => r.Name).IsRequired();
        }

        public abstract void Seed(BaseApplicationDbContext<TUser, TRole> context);

        public class DropCreateAlwaysInitializer : DropCreateDatabaseAlways<BaseApplicationDbContext<TUser, TRole>>
        {
            protected override void Seed(BaseApplicationDbContext<TUser, TRole> context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
        public class CreateDatabaseIfNotExistsInitializer : CreateDatabaseIfNotExists<BaseApplicationDbContext<TUser, TRole>>
        {
            protected override void Seed(BaseApplicationDbContext<TUser, TRole> context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
    }
}