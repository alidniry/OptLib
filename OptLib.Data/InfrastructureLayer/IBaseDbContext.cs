using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OptLib.Data.InfrastructureLayer
{
    public interface IBaseDbContext
    {
        //IDbSet<T> Set<T>() where T : class;

        Database Database { get; }
        DbChangeTracker ChangeTracker { get; }
        DbContextConfiguration Configuration { get; }
        void Dispose();
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        //[EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);
        //[EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        Type GetType();
        //[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        int SaveChanges();
        //[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "cancellationToken")]
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
        DbSet Set(Type entityType);
        //[SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Set")]
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //[EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();
        //void Dispose(bool disposing);
        //void OnModelCreating(DbModelBuilder modelBuilder);
        //bool ShouldValidateEntity(DbEntityEntry entityEntry);
        //DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items);
    }
}
