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
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void Dispose();
    }
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(object id);
        void Insert(TEntity entity);
    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //internal IDbContext Context;
        public DbContext Context;
        internal IDbSet<TEntity> DbSet;

        public Repository(/*IDbContext*/DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual TEntity FindById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
        }
        public virtual void Delete(object id)
        {
            var entity = DbSet.Find(id);
            //var objectState = entity as IObjectState;
            //if (objectState != null)
            //    objectState.State = ObjectState.Deleted;
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

        public virtual void Insert(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                DbSet.Add(entity);
            }
            else
            {
                entry.State = EntityState.Modified;
                //return null;
            }
            //DbSet.Attach(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
    }
    //public class UnitOfWork<TDbCtx, TEntity, /*TRep,*/ TKey> : IUnitOfWork<TDbCtx, TEntity, /*TRep,*/ TKey>
    //   where TDbCtx : DbContext, new()
    //   where TEntity : class, new()
    public class UnitOfWork<TDbCtx, TDbCtxLog /*, TRep, TEntity, TKey*/> //: IUnitOfWork<TDbCtx, TEntity, /*TRep,*/ TKey>
        where TDbCtx : DbContext, new()
        where TDbCtxLog : DbContext, new()
        //where TEntity : class, new()
        //where TRep : class, new()
        //where TRep : class, IRepository<TEntity, TKey>, new()
    {
        public List<IBaseRepository> lIRep { get; set; }
        //Dictionary<string, IBaseRepository> dIRep = new Dictionary<string, IBaseRepository>();
        public Dictionary<string, IBaseRepository> dIRep { get; private set; } = new Dictionary<string, IBaseRepository>();
        //Dictionary<string, IBaseRepository> dIRep = new Dictionary<string, IBaseRepository>();

        private readonly IDbContext _context;

        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, new()
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = $"Repository-{typeof(TEntity).Name}";

            if (_repositories.ContainsKey(type)) return (IRepository<TEntity>)_repositories[type];

            var repositoryType = typeof(Repository<>);

            var repositoryInstance =
                Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(TEntity)), _context);

            _repositories.Add(type, repositoryInstance);

            return (IRepository<TEntity>)_repositories[type];
        }
        public IRepository<TEntity, TKey> Repository3<TRep, TEntity, TKey>() where TEntity : class, new()
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = $"RepositorySec-{typeof(TEntity).Name}";

            if (_repositories.ContainsKey(type)) return (IRepository<TEntity, TKey>)_repositories[type];

            var repositoryType = typeof(TRep);
            var repositoryInstance =
                Activator.CreateInstance(repositoryType
                   /* .MakeGenericType(typeof(TRep))*/, _context);

            _repositories.Add(type, repositoryInstance);
            return (IRepository<TEntity, TKey>)_repositories[type];
        }


        private readonly TDbCtx _dbContext;
        //private TRep _repo;
        //private IRepository<dynamic, dynamic>[] _repo;
        //public IRepository<dynamic, dynamic>[] IRep
        //{
        //    get
        //    {
        //        return _repo;
        //    }
        //}
        public void AddRepository(string key, IBaseRepository iRep)
             //where TEntity : class, new()
        {
            dIRep.Add(key, iRep);
            var d = dIRep["ggg"];

            //lIRep.AddRange(iRep);
        }

        //public UnitOfWork(TDbCtx dbContext, TRep rep)
        //{
        //    _dbContext = dbContext;
        //    // Each repo will share the db context:
        //    _repo = rep;
        //}
        public UnitOfWork(TDbCtx dbContext/*, TRep[] rep*/, Dictionary<string, IBaseRepository> direp)
        {
            //_dbContext = dbContext;

            // Each repo will share the db context:
            _dbContext = dbContext;
            this.dIRep = direp;
            foreach (var item in this.dIRep)
            {
                item.Value.Context = _dbContext;
                //item.Value.Security = new
            }
            //_repo = rep;
            //foreach (var item in _repo)
            //{
            //    item.Context = _dbContext;

            //}
        }

        public bool BeginTransaction()
        {
            if (_dbContext.Database.Connection.State != System.Data.ConnectionState.Open)
            {
                _dbContext.Database.Connection.Open();
                return true;
            }
            return false;
        }
        //public int Save()
        //{
        //    //foreach (var item in _repo)
        //    //{
        //    //    item.Save();

        //    //}

        //    return 0;
        //}
        //public void Complete()
        //{
        //    Save();
        //}

        //public void Dispose()
        //{
        //    //foreach (var item in _repo)
        //    //{
        //    //    item.Dispose();

        //    //}

        //    //_dbContext.Dispose();
        //}
    }
}
