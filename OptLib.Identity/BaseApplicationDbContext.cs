using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OptLib.Identity.Models;

namespace OptLib.Identity
{
    public class BaseApplicationDbContext<TUser>
        : IdentityDbContext<TUser>
        where TUser : BaseApplicationUser//IdentityUser
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
        public BaseApplicationDbContext(string nameOrConnectionString, bool throwIfV1Schema) 
            : base(nameOrConnectionString, throwIfV1Schema)
        {

        }
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


        //public BaseApplicationDbContext(int a1)
        //    : base("IdentityConnection", throwIfV1Schema: false)
        //{
        //}
        //static BaseApplicationDbContext()
        //{
        //    // Set the database intializer which is run once during application start
        //    // This seeds the database with admin user credentials and admin role
        //    Database.SetInitializer<BaseApplicationDbContext>(new ApplicationDbInitializer());
        //}

        //public static BaseApplicationDbContext Create()
        //{
        //    return new BaseApplicationDbContext();
        //}
    }
}