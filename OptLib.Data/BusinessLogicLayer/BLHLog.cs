using Lib.DAL;
using Lib.DAL.Repository;
using Saman.DAL;
using Saman.DAL.Models;
using System;

namespace Lib.BAL
{
    public class BLHLog
        : bBL<DBContext, DBContext/*, HLog, IHLog, RepHLog, long*/>
        , IDisposable
    {
        public void Initialize()
        {
        }
        //public BLHLog(/*ClsABM1 abm,*/ short id)
        //    : base(/*abm,*/ id)
        //{
        //    Initialize();
        //}
        //public BLHLog(/*ClsABM1 abm*/)
        //    : base(/*abm*/)
        //{
        //    Initialize();
        //}

        public void Dispose()
        {
            base.Dispose();
        }
    }
}
