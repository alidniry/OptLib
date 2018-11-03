using Lib.Security;
using OptLib.Data.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using TRDc.Security;

namespace Lib.DAL.Repository
{
    //, in TKey
    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            //public static int GetItem<TDbCtx, TEntity, TKey>(this IBaseRepository ibrep, TKey id)
            //{
            //    return ibrep.Context.Set<TEntity>().de
            //}
        }
    }
    abstract public class Rep</*TDbCtx,*/ TEntity/*, TSecurity, eSP*/, TKey> 
        : /*IRepository<TEntity, TEntity>*/
        /*,*/ IDisposable
        //where TDbCtx : DbContext, new()
        where TEntity : class, IEntityId<TKey>, new()
        //where TSecurity : class, IOSecurity<eSP>, new()
    {
        public abstract SectionAccess<eSPermission1> Access { get; }

        public Rep(/*SectionAccess<eSPermission1> saccess*/)
        {
            //this._SectionAccess = saccess;
            //this.Context = new TDbCtx();
        }
        public Rep(DbContext context)
        {
            this.Context = context;
        }
        public Rep(DbContext context, IOSecurity1/*<eSP>*/ security/*, SectionAccess<eSPermission1> saccess*/)
            //: this(saccess)
        {
            this.Context = context;
            //this._SectionAccess = saccess;
            this._Security = security;
        }
        //protected TDbCtx _Context;
        public DbContext Context { get; set; }
        public IOSecurity1 Security { set { _Security = value; } }
        //public SectionAccess<eSPermission1> SectionAccess { set { _SectionAccess = value; } }

        internal DbSet<TEntity> _DBSet { get { return this.Context.Set<TEntity>(); } }
        //protected SectionAccess<eSPermission1> _SectionAccess { get; set; }
        protected IOSecurity1/*<eSP>*/ _Security;

        abstract protected void ArgumentNotNull(TEntity value);

        //virtual public void Insert(System.Data.Entity.DbSet<TEntity> setT, TEntity value, hbId<PKType> bHis)
        //{
        //    if (_Security.Authentication)
        //    {
        //        bHis.SetHistoryCreate((int)_Security.UserID);
        //        bHis.SetHistoryLastChanges((int)_Security.UserID);

        //        Insert(setT, value);
        //    }
        //    else
        //        throw new AuthenticationException();//" User not Authentication");
        //}
        //virtual public void Update(hbId<PKType> bHis)
        //{
        //    if (_Security.Authentication)
        //    {
        //        bHis.SetHistoryLastChanges((int)_Security.UserID);
        //    }
        //    else
        //        throw new AuthenticationException();//" User not Authentication");
        //}
        //virtual public void Delete(hbId<PKType> bHis)
        //{
        //    if (_Security.Authentication)
        //    {
        //        bHis.SetHistoryLastChanges((int)_Security.UserID);
        //        bHis.SetHistoryDelet((int)_Security.UserID);
        //        bHis.DEL = true;
        //    }
        //    else
        //        throw new AuthenticationException();//" User not Authentication");
        //}
        //private readonly DbContext Context;
        //protected DbContext Context { get; set; }
        //public Rep()
        //{
        //    if (_Context ==  null)
        //        _Context = new TDbCtx();
        //}
        //public Rep(TDbCtx context, IOSecurity1/*<eSP>*/ security, SectionAccess<eSPermission1> saccess)

        //public Rep(DbContext ctx)
        //{
        //    Context = ctx;
        //}
        //public IQueryable<T> GetAll()
        //{

        //    IQueryable<T> query = context.Things;
        //    return query;
        //}
        //private TDbCtx _entities;
        //protected TDbCtx db { get { return _entities; } set { _entities = value; } }
        virtual protected void Permission(eSPermission1 saccess)
        {
            //if (!_Security.Authentication)
            //    throw new AuthenticationException(string.Format("User not Authentication"));
            //if (!_Security.CheackPermission((int)(object)saccess))
            //    throw new UnauthorizedAccessException(string.Format("You dont have Permission ({0}) in Table : {1} ", saccess.ToString(), TableName));
        }

        public virtual TEntity Get(TKey id)
        {
            //Permission(_SectionAccess.GetItem);
            //if (id == null)
            //    throw new ArgumentNullException(string.Format("Argument 'ID' cannot was null"));
            return _DBSet.Find(id);
        }
        //public virtual TEntity Get(params object[] keyValues)
        //{
        //    return _DBSet.Find(keyValues);
        //}
        //public virtual TEntity Get(TEntity entity)
        //{
        //    return _DBSet.Find(entity);
        //}
        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        //public virtual List<TEntity> GetAll(DbContext context)
        //{
        //    return context.Set<TEntity>().ToList();
        //}
        public virtual List<TEntity> GetAll()
        {
            //if (Access.GetList == eSPermission1.GUEST_PUBLIC || (_Security==null ? false : _Security.CheackPermission((int)Access.GetList)))
                return Context.Set<TEntity>().ToList();
            //return new List<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }
        public virtual IQueryable<TEntity> GetAllEntity()
        {
            return Context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> GetAllEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetList(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _DBSet;

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
            ArgumentNotNull(entity);

            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                return Context.Set<TEntity>().Add(entity);
            }
            else
            {
                entry.State = EntityState.Modified;
                return null;
            }
        }
        public void AddAll(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void Edit(TEntity entity)
        {
            //dbSet.Attach(entity);
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public virtual void Remove(object id)
        {
            TEntity entityToRemove = _DBSet.Find(id);
            Remove(entityToRemove);
        }
        public virtual void Remove(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            //dbSet.Remove(entity);
            Context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }
        public virtual void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in Context.Set<TEntity>().Where(predicate))
            {
                Remove(entity);
            }
        }
        public virtual void RemoveAll(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            //throw new NotImplementedException();
        }


    }
}
