using Lib.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TRDc.Security;

namespace Lib.DAL.Repository
{
    public interface IRepository<TEntity, TKey> : IBaseRepository, IDisposable
        where TEntity : class
    {
        DbContext Context { get; set; }
        IOSecurity1 Security { set; }
        //SectionAccess<eSPermission1> SectionAccess { set; }
        //SectionAccess<eSPermission1> access { get; }
        SectionAccess<eSPermission1> Access { get; }

        TEntity Get(TKey id);
        //TEntity Get(params object[] keyValues);
        //TEntity Get(TKey id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        //Task<TEntity> GetAsnyc(TKey id);

        List<TEntity> GetAll();
        //List<TEntity> GetAll(DbContext context);

        //IEnumerable<TEntity> GetAll();
        //Task<IEnumerable<TEntity>> GetAllAsync();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);

        void Edit(TEntity entity);

        void Remove(object id);
        void Remove(TEntity entity);
        void Remove(Expression<Func<TEntity, bool>> predicate);
        void RemoveAll(IEnumerable<TEntity> entities);

        int Save();
    }
}
