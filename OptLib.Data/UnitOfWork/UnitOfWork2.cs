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
    public class UnitOfWork2
    {
        public IDbContext2 Context { get; private set; }
        public IDbContext2 ContextLog { get; private set; }

        private readonly IDbContext2 _Context;
        private readonly IDbContext2 _ContextLog;

        private Hashtable _repositories;
        public List<dynamic> ListHistory { get; set; }

        public UnitOfWork2(IDbContext2 context, IDbContext2 contextlog)
        {
            _Context = context;
            _ContextLog = contextlog;
        }

        public IRepository2<TEntity> Repository<TEntity>() where TEntity : class, new()
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = $"Repository-{typeof(TEntity).Name}";

            if (_repositories.ContainsKey(type)) return (IRepository2<TEntity>)_repositories[type];

            var repositoryType = typeof(Repository2<>);

            var repositoryInstance =
                Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(TEntity)), _Context, this, 1);

            _repositories.Add(type, repositoryInstance);

            return (IRepository2<TEntity>)_repositories[type];
        }
        public IRepository2<TDbCtx, TEntity, TEntitylog> Repository<TDbCtx, TEntity, TEntitylog>()
            where TDbCtx : DbContext
            where TEntity : class
            where TEntitylog : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = $"Repository-{typeof(TEntity).Name}";

            if (_repositories.ContainsKey(type)) return (IRepository2<TDbCtx, TEntity, TEntitylog>)_repositories[type];

            var repositoryType = typeof(Repository2<,,>);

            var repositoryInstance =
                Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(TDbCtx), typeof(TEntity), typeof(TEntitylog)), _Context, _ContextLog, this, 1);

            _repositories.Add(type, repositoryInstance);

            return (IRepository2<TDbCtx, TEntity, TEntitylog>)_repositories[type];
        }

        //public IRepository<TEntity, TKey> Repository<TRep, TEntity, TKey>()
        //    where TRep : class
        //    where TEntity : class
        //{
        //    if (_repositories == null)
        //        _repositories = new Hashtable();

        //    var type = $"RepositorySec-{typeof(TEntity).Name}";

        //    if (_repositories.ContainsKey(type)) return (IRepository<TEntity, TKey>)_repositories[type];

        //    var repositoryType = typeof(TRep);
        //    var repositoryInstance =
        //        Activator.CreateInstance(repositoryType
        //           /* .MakeGenericType(typeof(TRep))*/, _Context);

        //    _repositories.Add(type, repositoryInstance);
        //    return (IRepository<TEntity, TKey>)_repositories[type];
        //}

        public void Save()
        {
            _Context.SaveChanges();

           
               

            _ContextLog.SaveChanges();
        }

        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                {
                    _Context.Dispose();
                    _ContextLog.Dispose();
                }
            _disposed = true;
        }
    }
}
