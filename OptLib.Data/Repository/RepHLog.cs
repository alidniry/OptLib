using System;
using System.Data.Entity;
using Lib.Security;
using TRDc.Security;
using System.Collections.Generic;
using Saman.DAL.Models;

namespace Lib.DAL.Repository
{
    public class RepHLog 
        : Rep<HLog, long>
        , IRepository<HLog, long>
        , IDisposable
    {
        public override SectionAccess<eSPermission1> Access
        {
            get
            {
                return new SectionAccess<eSPermission1>(
                    eSPermission1.GUEST_PUBLIC,
                    eSPermission1.GUEST_PUBLIC
                    //,
                    //eSPermission1.NONE,
                    //eSPermission1.NONE,
                    //eSPermission1.NONE,
                    //eSPermission1.NONE,
                    //eSPermission1.NONE,
                    //eSPermission1.NONE
                    );
            }
        } 
            
        public RepHLog()
            : base() 
        {
        }

        public RepHLog(DbContext context, IOSecurity1 security)
            : base(context, security)
        {
        }

        /// <summary>
        /// نبودن آرگومان های اصلی null تابع بررسی  
        /// </summary>
        override protected void ArgumentNotNull(HLog value)
        {
            //if (value.ID == null)
            //    throw new ArgumentNullException($"Argument '{value.ID.GetType().Name}' cannot was null");
        }
    }
}
