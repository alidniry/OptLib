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
        public IBaseDbContext Context { get; private set; }
        public IDbSet<TEntity> DbSet { get; private set; }
        public int MemberId { get; private set; }
        public UnitOfWork UFW { get; set; }

        public BaseRepository(IBaseDbContext context, UnitOfWork ufw, int mid)
        {
            this.Context = context;
            this.MemberId = mid;
            this.UFW = ufw;
            this.DbSet = Context.Set<TEntity>();
        }

        public virtual TEntity GetItem(object id)
        {
            return this.DbSet.Find(id);
        }
        public virtual TEntity GetItem(object id, long cpKey)
        {
            return this.DbSet.Find(id, cpKey);
        }
        public virtual TEntity GetItem(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate).FirstOrDefault();
        }

        public virtual IQueryable<TEntity> GetEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate);
        }
        public virtual IQueryable<TEntity> GetEntity(
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
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            //if (Access.GetList == eSPermission1.GUEST_PUBLIC || (_Security == null ? false : _Security.CheackPermission((int)Access.GetList)))
                return this.DbSet;
        }

    }
}
