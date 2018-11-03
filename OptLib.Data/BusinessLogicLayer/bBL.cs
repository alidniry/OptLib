using ABMLib.DAL.LocalDB;
using Lib.DAL;
using Lib.DAL.Repository;
using Lib.Security;
using OptLib.Data.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using TRDc.Security;

namespace Lib.BAL
{
    abstract public class bBL<TDbCtx, TDbCtxLog/*, TEntity, IOListT, TRep, TKey*/>
        : IDisposable
        where TDbCtx : DbContext, new()
        where TDbCtxLog : DbContext, new()
        //where TEntity : class, IEntityId<TKey>, new()
        //where TRep : class, IRepository<TEntity, TKey>, new()
        //where TRep : class, new()
    {
        public bBL(UnitOfWork2/*<TDbCtx, TDbCtxLog>*/ ufw)
        {
            this.UFW = ufw;
        }
        //static bBL()
        //{
        //    CASH = false;
        //}
        //public ClsABM1 ABM { get; private set; }
        //public bBL()
        //{
        //    this._Repository = new TRep();
        //}
        protected UnitOfWork2/*<TDbCtx, TDbCtxLog>*/ UFW { get; set; } //= new UnitOfWork<TDbCtx, TDbCtxLog>(new TDbCtx());
        //public bBL(/*ClsABM1 abm*/)
        //{
            //ABM = abm;
            //this._Repository = new[] { new TRep() { Context = new TDbCtx()/*, Security = ABM.Security*/ } };
            //using (var ufw = UnitOfWork)
            //{
            //    using (IRepository<TEntity, TKey> rep = ufw.IRep)
            //    {
            //        //this.Info = GetItem(id);
            //    }
            //}
        //}

        //public bBL(/*ClsABM1 abm,*/ /*TKey id*/)
        //    : this(/*abm*/)
        //{
        //    //using (var ufw = UnitOfWork)
        //    //{
        //    //    using (IRepository<TEntity, TKey> rep = ufw.IRep[0])
        //    //    {
        //    //        this.Info = GetItem(id);
        //    //    }
        //    //}
        //}
        //public bBL(/*ClsABM1 abm,*/ /*TEntity entity*/)
        //    : this(/*abm*/)
        //{
        //    //this.Info = entity;
        //    //using (var ufw = UnitOfWork)
        //    //{
        //    //    using (IRepository<TEntity, TKey> rep = ufw.IRep)
        //    //    {
        //    //        //var tEntity = this.Info = GetItem(entity.id)
        //    //    }
        //    //}
        //}

        //public bBL(/*TRep[] repository*/)
        //{
        //    //this._Repository = repository;
        //    //_Repository.Context = new TDbCtx();
        //    //UnitOfWork = new UnitOfWork<TDbCtx, TEntity, TKey>((TDbCtx)repository.Context, _Repository);
        //    //using (var ufw = _UnitOfWork)
        //    //{
        //    //    using (var rep = ufw.IRep)
        //    //        Refrash();
        //    //}
        //}

        ///// <summary>
        ///// Initializes a new instance of the <see cref="bBL{TDbCtx, TDbCtxLog}"/> class.
        ///// </summary>
        ///// <param name="repository">The repository.</param>
        ///// <param name="id">The identifier.</param>
        //public bBL(/*TRep[] repository, TKey id*/)
        //    //: this(repository)
        //{
        //    //using (var ufw = UnitOfWork)
        //    //{
        //    //    using (IRepository<TEntity, TKey> rep = ufw.IRep[0])
        //    //    {
        //    //        this.Info = GetItem(id);
        //    //    }
        //    //}
        //}
        //public bBL(/*TRep[] repository, TEntity entity*/)
        //    //: this(repository)
        //{

        //    //using (var ufw = UnitOfWork)
        //    //{
        //    //    using (IRepository<TEntity, TKey> rep = ufw.IRep[0])
        //    //    {
        //    //        this.Info = GetItem(entity.Id);
        //    //    }
        //    //}
        //}



        //public IRepository<TEntity, TKey>[] _Repository { get; private set; }
        //protected UnitOfWork<TDbCtx, TDbCtxLog /*,TRep, TKey*/> UnitOfWork
        //{
        //    get { return new UnitOfWork<TDbCtx, TDbCtxLog /*,TRep, TKey*/>(new TDbCtx()/*_Repository*/); }//new TRep()
        //}
        //static public UnitOfWork<TDbCtx, TEntity, /*TRep,*/ TKey> _UnitOfWork { get; private set; }

        //protected IRepository<TEntity> rep { get; set; }
        //public List<TEntity> Rows
        //{
        //    get
        //    {
        //        //if (CASH == false || (mRows != null ? (mRows.Count <= 0 ? true : false) : true))
        //        //{
        //            var rep = new TRep()
        //            {
        //                Context = new TDbCtx(),
        //                //Security = (ABM == null ? null : ABM.Security),
        //            };
        //            //CASH = (rep.Access.GetList == eSPermission1.GUEST_PUBLIC &&
        //            //        rep.Access.Insert == 0 &&
        //            //        rep.Access.Update == 0 &&
        //            //        rep.Access.Delete == 0 &&
        //            //        rep.Access.Del == 0 &&
        //            //        rep.Access.Active == 0 &&
        //            //        rep.Access.Block == 0
        //            //);
        //            mRows = rep.GetAll( /*new TDbCtx()*/).ToList();
        //        //}
        //        return mRows;
        //    }
        //}
        //public List<IOListT> IRows { get { return Rows.Cast<IOListT>().ToList(); } }
        //protected static List<TEntity> mRows = new List<TEntity>();
        //static public bool CASH { get; protected set; } = false;
        //public static List<TEntity> sRows
        //{
        //    get
        //    {
        //        //if (CASH == false || (mRows != null ? (mRows.Count <= 0 ? true : false) : true))
        //        //{
        //            var rep = new TRep()
        //            {
        //                Context = new TDbCtx(),
        //            };
        //            //CASH = (rep.Access.GetList == eSPermission1.GUEST_PUBLIC &&
        //            //        rep.Access.Insert == 0 &&
        //            //        rep.Access.Update == 0 &&
        //            //        rep.Access.Delete == 0 &&
        //            //        rep.Access.Del == 0 &&
        //            //        rep.Access.Active == 0 &&
        //            //        rep.Access.Block == 0
        //            //);
        //            mRows = rep.GetAll( /*new TDbCtx()*/).ToList();
        //        //}
        //        return mRows;
        //    }
        //}
        //static public List<IOListT> sIRows { get { return sRows.Cast<IOListT>().ToList(); } }

        //public static DataTable sTableRows
        //{
        //    get { return ClsExtendedLibrary.ConvertToDataTable<TEntity>(sRows); }
        //}
        //public DataTable TableRows
        //{
        //    get { return ClsExtendedLibrary.ConvertToDataTable<TEntity>(Rows); }
        //}
        //public static DataTable sTableIRows
        //{
        //    get { return ClsExtendedLibrary.ConvertToDataTable<IOListT>(sIRows); }
        //}
        //public DataTable TableIRows
        //{
        //    get { return ClsExtendedLibrary.ConvertToDataTable<IOListT>(IRows); }
        //}

        //public TEntity Info { get; set; } = new TEntity();

        //public bBL(IRepository<TEntity> rep)
        //{
        //    //this.rep = rep;
        //}
        //public List<TEntity> xsRows
        //{
        //    get
        //    {
        //        if (xmRows == null)
        //            xmRows = new RepThing().GetAll().ToList();
        //        return xmRows;
        //    }
        //}


        //virtual public TEntity GetItem(int id)
        //{
        //    using (var ufw = UnitOfWork)
        //    {
        //        using (IRepository<TEntity> rep = ufw.IRep)
        //        {
        //            Info = rep.Get(id);
        //            return Info;
        //        }
        //    }
        //    return null;
        //}

        //public void Refrash()
        //{
        //    sRefrash();
        //}
        //virtual public bool Insert()
        //{
        //    return Insert(Info);
        //}
        //virtual public bool Update()
        //{
        //    return Update(Info);
        //}
        //virtual public bool Delete()
        //{
        //    return Delete(Info);
        //}

        //public static void sRefrash()
        //{
        //    mRows = new TRep().GetAll().ToList();
        //}

        //public TEntity GetItem(TKey id)
        //{
        //    //using (var ufw = UnitOfWork)
        //    //{
        //    //    using (IRepository<TEntity, TKey> rep = ufw.IRep[0])
        //    //    {
        //    //        return rep.Get(id);
        //    //    }
        //    //}
        //    return null;
        //}
        //public bool Insert(TEntity info)
        //{
        //    //using (var ufw = UnitOfWork)
        //    //{
        //    //    using (IRepository<TEntity, TKey> rep = ufw.IRep[0])
        //    //    {
        //    //        info = rep.Add(info);
        //    //        rep.Save();
        //    //        mRows = rep.GetAll();
        //    //        return true;
        //    //    }
        //    //}
        //    return false;
        //}
        //public bool Update(TEntity info)
        //{
        //    //using (var ufw = UnitOfWork)
        //    //{
        //    //    using (IRepository<TEntity, TKey> rep = ufw.IRep[0])
        //    //    {
        //    //        rep.Edit(info);
        //    //        rep.Save();
        //    //        mRows = rep.GetAll();
        //    //        return true;
        //    //    }
        //    //}
        //    return false;
        //}
        //public bool Delete(TEntity info)
        //{
        //    //using (var ufw = UnitOfWork)
        //    //{
        //    //    using (IRepository<TEntity, TKey> rep = ufw.IRep[0])
        //    //    {
        //    //        rep.Remove(info);
        //    //        rep.Save();
        //    //        mRows = rep.GetAll();
        //    //        return true;
        //    //    }
        //    //}
        //    return false;
        //}

        //public bool DeleteUser(string UserID) //static
        //{
        //    try
        //    {
        //        //var unitOfWork = new UnitOfWork(new LocalDBContext());
        //        //var userRepository = unitOfWork.RThing;
        //        using (var ufw = new UnitOfWork<TDbCtx, TEntity>(new TDbCtx()))
        //        {
        //            using (var rep = ufw.IRep)
        //            {
        //                //User UserTobeRemoved = userRepository.SelectByKey(UserID);
        //                //if (UserTobeRemoved == null)
        //                //    return false;

        //                //userRepository.DeleteRelatedEntries(UserTobeRemoved);
        //                //userRepository.Delete(UserTobeRemoved);
        //                rep.Remove(2);
        //                if (ufw.Save() >= 0)
        //                    return true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return false;
        //}
        public void Dispose()
        {
            //IRep = null;
        }
    }
}
