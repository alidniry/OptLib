using Lib.DAL;
using Lib.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMLib.DAL.LocalDB
{
    public class UnitOfWork<TDbCtx, TEntity, /*TRep,*/ TKey> : IUnitOfWork<TDbCtx, TEntity, /*TRep,*/ TKey>
        where TDbCtx : DbContext, new()
        where TEntity : class, new()
        //where TRep : class, IRepository<TEntity, TKey>, new()
    {
        private readonly TDbCtx _dbContext;
        //private TRep _repo;
        private IRepository<TEntity, TKey> _repo;
        public IRepository<TEntity, TKey> IRep
        {
            get
            {
                return _repo;
            }
        }

        //public UnitOfWork(TDbCtx dbContext, TRep rep)
        //{
        //    _dbContext = dbContext;
        //    // Each repo will share the db context:
        //    _repo = rep;
        //}
        public UnitOfWork(TDbCtx dbContext, IRepository<TEntity, TKey> rep)
        {
            //_dbContext = dbContext;

            // Each repo will share the db context:
            _repo = rep;
            _repo.Context = new TDbCtx();
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
        public int Save()
        {
            return _repo.Save();
        }
        public void Complete()
        {
            Save();
        }

        public void Dispose()
        {
            //_dbContext.Dispose();
            _repo.Dispose();
        }
    }
}
