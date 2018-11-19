using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.Data.InfrastructureLayer
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        TEntity GetEntityById(object id);
        TEntity Add(TEntity entity);
        List<TEntity> GetAll();
        //void Insert(TEntity entity);
    }
    public interface IRepository<TEntity, TRep> : IBaseRepository<TEntity>
        where TEntity : class
        where TRep : BaseRep<TEntity>
    {
    }
    public interface IRepository<TDbCtx, TEntity, TRep, TEntitylog> : IBaseRepository<TEntity>
        where TDbCtx : DbContext
        where TEntity : class
        where TRep : BaseRep<TEntity>
        where TEntitylog : class
    {
    }
}
