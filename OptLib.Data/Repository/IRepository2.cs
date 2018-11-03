using Lib.DAL;
using Lib.DAL.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMLib.DAL.LocalDB
{
    public interface IRepository2<TEntity>
        where TEntity : class
    {
        TEntity GetEntityById(object id);
        TEntity Add(TEntity entity);
        //void Insert(TEntity entity);
    }
    public interface IRepository2<TDbCtx, TEntity, TEntitylog>
        where TDbCtx : DbContext
        where TEntity : class
        where TEntitylog : class
    {
        TEntity GetEntityById(object id);
        TEntity Add(TEntity entity);
        //void Insert(TEntity entity);
    }
}
