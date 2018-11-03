using ABMLib.DAL.LocalDB;
using Lib.DAL;
using Lib.DAL.Repository;
using Saman.DAL;
using Saman.DAL.Models;
using Saman.DAL.ModelsHLog;
using StructureMap;
using System;

namespace Lib.BAL
{
    public class BLQdtAction
        : bBL<DBContext, DBContextHLog/*, QdtAction, IBarcodeTypeList, RepQdtAction, long*/>, IDisposable, IBLQdtAction
    {
        public void Initialize()
        {
        }
        public BLQdtAction(IDbContext2 context/*,ClsABM1 abm,*/ /*short id*/)
            : base(
                  new ABMLib.DAL.LocalDB.UnitOfWork2/*<DBContext, DBContextHLog>*/(new DBContext(), new DBContextHLog()
                    //, 
                    //new System.Collections.Generic.Dictionary<string, IBaseRepository>() {
                    //{"RepQdtAction", new RepQdtAction()},
                    //}
                    )/*abm,*//* id*/)
        {
            _Context = context;
            Initialize();
        }
        private readonly IDbContext2 _Context;

        public void dddd()
        {
            var ufw = new ABMLib.DAL.LocalDB.UnitOfWork2(_Context, new DBContextHLog());

            var H = UFW.Repository<HLog>();

            var r = UFW.Repository<DBContext, QdtAction, QdtActionHLog>();
            //var r2 = UFW.Repository<RepQdtAction , QdtAction, long>();
            //var fff1 = r2.GetAll();
            //r2.Add(new QdtAction());
            r.Add(new QdtAction());
            H.Add(new HLog("ثبت داده QdtAction"));
            UFW.Save();
            //var fff2 = r2.GetAll();
            var it = r.GetEntityById(1);
            it.Name = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            r.Add(it);
            UFW.Save();
            UFW.Dispose();
            //UFW.dIRep["RepQdtAction"].
        }
        //public BLQdtAction(/*ClsABM1 abm*/)
        //    //: base(/*abm*/)
        //{
        //    Initialize();
        //}

        public void Dispose()
        {
            base.Dispose();
        }
    }
}
