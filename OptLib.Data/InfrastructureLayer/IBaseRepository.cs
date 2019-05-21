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
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        TEntity GetItem(object id);
        TEntity GetItem(object id, long cpKey);
        TEntity GetItem(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetEntity(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetEntity(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        IQueryable<TEntity> GetAll();

        TEntity Add(TEntity entity);
        //void Insert(TEntity entity);
    }
}
