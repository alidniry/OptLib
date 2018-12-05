using AutoMapper;
using OptLib.Data.Base;
using OptLib.Data.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.Data.InfrastructureLayer
{
    public abstract class BaseRepository<TEntity>
        where TEntity : class
    {

    }
    public class Repository<TEntity, TRep> : BaseRepository<TEntity>, IRepository<TEntity, TRep>
        where TEntity : class
        where TRep : BaseRep<TEntity>
    {
        public IBaseDbContext Context { get; private set; }
        public IDbSet<TEntity> DbSet { get; private set; }
        public int MemberId { get; private set; }
        public UnitOfWork UFW { get; set; }
        public Repository(IBaseDbContext context, UnitOfWork ufw, int mid)
        {
            this.Context = context;
            this.DbSet = Context.Set<TEntity>();
            this.MemberId = mid;
            this.UFW = ufw;
        }

        public TEntity GetEntityById(object id)
        {
            return this.DbSet.Find(id);
        }

        public TEntity Add(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                var tentity = Context.Set<TEntity>().Add(entity);

                Context.SaveChanges();
                return tentity;
            }
            else
            {
                entry.State = EntityState.Modified;
                return entity;
            }
        }

        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
    }
    public class Repository<TDbCtx, TEntity, TRep, TEntitylog> : BaseRepository<TEntity>, IRepository<TDbCtx, TEntity, TRep, TEntitylog>
        where TDbCtx : DbContext, new()
        where TEntity : class
        where TRep : BaseRep<TEntity>
        where TEntitylog : class, new()
    {
        //internal IDbContext Context;
        //public DbContext _Context;
        //public IDbSet<TEntity> _DbSet;
        public IBaseDbContext Context { get; private set; }
        public IBaseDbContext ContextLog { get; private set; }
        public IDbSet<TEntity> DbSet { get; private set; }
        public IDbSet<TEntity> DbSetLog { get; private set; }
        //public IDbSet<TEntity> DBSet2 { get { return this.Context.Set<TEntity>(); } }
        public int MemberId { get; private set; }
        public UnitOfWork UFW { get; set; }
        public Repository(/*IDbContext*/IBaseDbContext context, IBaseDbContext contextLog, UnitOfWork ufw, int mid)
        {
            this.Context = context;
            this.ContextLog = contextLog;
            this.DbSet = Context.Set<TEntity>();
            this.DbSetLog = ContextLog.Set<TEntity>();
            this.MemberId = mid;
            this.UFW = ufw;
        }

        public virtual TEntity GetEntityById(object id)
        {
            return this.DbSet.Find(id);
        }
        public virtual TEntity GetFirstOrDefaultByExpressionFunc(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate).FirstOrDefault();
        }

        public virtual List<TEntity> GetListAll()
        {
            //if (Access.GetList == eSPermission1.GUEST_PUBLIC || (_Security==null ? false : _Security.CheackPermission((int)Access.GetList)))
            return this.DbSet.ToList();
            //return new List<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetIEnumerableAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate).ToList();
        }
        public virtual IQueryable<TEntity> GetIQueryableAllEntity()
        {
            return this.DbSet;
        }
        public virtual IQueryable<TEntity> GetAllEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetList(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = this.DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity Add(TEntity entity)
        {
            //Permission(_SectionAccess.GetItem);
            //ArgumentNotNull(entity);


            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                ((IHistory)entity).History = new OptLib.Data.ComplexType._History(this.MemberId);
                var tentity = Context.Set<TEntity>().Add(entity);
                Context.SaveChanges();

                TEntitylog logDTO = Mapper.Map<TEntity, TEntitylog>(tentity);
                ((IHistoryLog<long>)logDTO).HistoryLog =
                    new OptLib.Data.ComplexType._HistoryLog(this.MemberId, eHistoryLog.CREATE);
                //((IHistoryLog<long>)logDTO).HistoryLog.ActorID = this.MemberId;
                //((IHistoryLog<long>)logDTO).HistoryLog.Activety = eHistoryLog.CREATE;
                //((IHistoryLog<long>)logDTO).HistoryLog.Date = DateTime.Now;
                var tentityLog = ContextLog.Set<TEntitylog>().Add(/*entityLog*/logDTO);

                return tentity;
            }
            else
            {
                using (var ctx = new TDbCtx())
                {
                    var old = ctx.Set<TEntity>().Find(((IEntityBaseId<long>)entity).Id);
                    TEntitylog OldlogDTO = Mapper.Map<TEntity, TEntitylog>(old);
                    ((IHistoryLog<long>)OldlogDTO).HistoryLog =
                        new OptLib.Data.ComplexType._HistoryLog(this.MemberId, eHistoryLog.CHANGE);
                    var OldtentityLog = ContextLog.Set<TEntitylog>().Add(/*entityLog*/OldlogDTO);

                    //TEntitylog NewlogDTO = Mapper.Map<TEntity, TEntitylog>(entity);
                    //((IHistoryLog<long>)NewlogDTO).HistoryLog =
                    //    new OptLib.Data.ComplexType._HistoryLog(this.MemberId, eHistoryLog.CHANGE_NEW);
                    //var NewtentityLog = ContextLog.Set<TEntitylog>().Add(/*entityLog*/NewlogDTO);
                }
                ((IHistory)entity).History.SetLastModifier(this.MemberId);
                //((IEntityId<long>)entity).Id;

                entry.State = EntityState.Modified;
                return entity;
            }
        }

        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }




        //public virtual TEntity FindById(object id)
        //{
        //    return _DbSet.Find(id);
        //}

        //public virtual void Update(TEntity entity)
        //{
        //    _DbSet.Attach(entity);
        //}
        //public virtual void Delete(object id)
        //{
        //    var entity = _DbSet.Find(id);
        //    //var objectState = entity as IObjectState;
        //    //if (objectState != null)
        //    //    objectState.State = ObjectState.Deleted;
        //    Delete(entity);
        //}

        //public virtual void Delete(TEntity entity)
        //{
        //    _DbSet.Attach(entity);
        //    _DbSet.Remove(entity);
        //}

        //public virtual void Insert(TEntity entity)
        //{
        //    var entry = _Context.Entry(entity);
        //    if (entry.State == EntityState.Detached)
        //    {
        //        _DbSet.Add(entity);
        //    }
        //    else
        //    {
        //        entry.State = EntityState.Modified;
        //        //return null;
        //    }
        //    //DbSet.Attach(entity);
        //}

        //public virtual List<TEntity> GetAll()
        //{
        //    return _DbSet.ToList();
        //}
    }
}
