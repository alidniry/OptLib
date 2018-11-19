using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.Data.InfrastructureLayer
{
    public class UnitOfWork
    {
        public IBaseDbContext Context { get; private set; }
        public IBaseDbContext ContextLog { get; private set; }

        private readonly IBaseDbContext _Context;
        private readonly IBaseDbContext _ContextLog;

        private Hashtable _repositories;
        public List<dynamic> ListHistory { get; set; }

        public UnitOfWork(IBaseDbContext context, IBaseDbContext contextlog)
        {
            _Context = context;
            _ContextLog = contextlog;
        }

        public IRepository<TEntity, TRep> GetRepository<TEntity, TRep>()
            where TEntity : class, new()
            where TRep : BaseRep<TEntity>
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = $"Repository-{typeof(TEntity).Name}";

            if (_repositories.ContainsKey(type)) return (IRepository<TEntity, TRep>)_repositories[type];

            //Type myType1 = Type.GetType($"Lib.DAL.Repository.Rep{typeof(TEntity).Name}");

            var repositoryType = typeof(Repository<,>);

            var repositoryInstance =
                Activator.CreateInstance(/*myType1*/repositoryType
                    .MakeGenericType(typeof(TEntity), typeof(TRep)), _Context, this, 1);

            _repositories.Add(type, repositoryInstance);

            return (IRepository<TEntity, TRep>)_repositories[type];
        }
        public IRepository<TDbCtx, TEntity, TRep, TEntitylog> GetRepository<TDbCtx, TEntity, TRep, TEntitylog>()
            where TDbCtx : DbContext
            where TEntity : class
            where TRep : BaseRep<TEntity>
            where TEntitylog : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = $"Repository-{typeof(TEntity).Name}";

            if (_repositories.ContainsKey(type)) return (IRepository<TDbCtx, TEntity, TRep, TEntitylog>)_repositories[type];

            //Type myType1 = Type.GetType($"Lib.DAL.Repository.Rep{typeof(TEntity).Name}");
            var repositoryType = typeof(Repository<,,,>);

            var repositoryInstance =
                Activator.CreateInstance(/*myType1*/repositoryType
                    .MakeGenericType(typeof(TDbCtx), typeof(TEntity), typeof(TRep), typeof(TEntitylog)), _Context, _ContextLog, this, 1);

            _repositories.Add(type, repositoryInstance);

            return (IRepository<TDbCtx, TEntity, TRep, TEntitylog>)_repositories[type];
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
