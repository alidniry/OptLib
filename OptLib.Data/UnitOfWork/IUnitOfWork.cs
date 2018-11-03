using Lib.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Lib.DAL
{
    //public interface IUnitOfWork : IDisposable
    //{
    //    IDbSet<TEntity> Set<TEntity>() where TEntity : class;
    //    int SaveAllChanges(bool invalidateCacheDependencies = true);
    //    Task<int> SaveAllChangesAsync(bool invalidateCacheDependencies = true);
    //    void MarkAsAdded<TEntity>(TEntity entity) where TEntity : class;
    //    void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class;
    //    void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class;
    //    IList<T> GetRows<T>(string sql, params object[] parameters) where T : class;
    //    IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    //    void ForceDatabaseInitialize();
    //    Database Database { get; }
    //    DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    //}
    public interface IUnitOfWork<TDbCtx, TEntity, /*TRep,*/ TKey> : IDisposable
        where TDbCtx : DbContext, new()
        where TEntity : class, new()
        //where TRep : class, IRepository<TEntity, TKey>, new()
    {
        // Commit all the changes 
        void Complete();

        // Concrete implementation -> IRepository<Foo>
        // Add all your repositories here:
        //TRep IRep { get; }
        IRepository<TEntity, TKey>[] IRep { get; }
        int Save();
    }
}

