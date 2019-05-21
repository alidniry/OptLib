using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Reflection;
//using EFSecondLevelCache; //D:\[PROJECTS]\Taradis Company\ABM\packages\EFSecondLevelCache.1.2.0.0\readme.txt
using System.Diagnostics;
using OptLib.Data.ExtensionMethods;
using System.Data.SqlClient;
using OptLib.Data;
using System.Data.Entity.Migrations;
using OptLib.ExtensionMethods;
//using TRDc.ExtensionException;

namespace QptLib.Data
{
    //public interface IContext<TContext>
    //{
    //    void Seed(TContext context);
    //}

    public abstract partial class BaseDatabaseContext<TContext>
        : DbContext, IDisposable, IObjectContextAdapter
        where TContext : BaseDatabaseContext<TContext>
    {
        public static bool _InitialCreation = false;
        public bool InitialCreation { get { return _InitialCreation; } set { _InitialCreation = value; } }


        protected BaseDatabaseContext()
            : base()
        {
            InitializeDatabase();
        }
        protected BaseDatabaseContext(DbCompiledModel model)
            : base(model)
        {
            InitializeDatabase();
        }

        public BaseDatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            InitializeDatabase();
        }
        public BaseDatabaseContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
            InitializeDatabase();
        }
        public BaseDatabaseContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            InitializeDatabase();
        }
        public BaseDatabaseContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
            InitializeDatabase();
        }
        public BaseDatabaseContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!Database.Exists())
            {
                InitialCreation = true;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Add<BaseModelConfigurationConvention>();
        }
        //public abstract void Seed(TContext context);

        public class CreateDatabaseIfNotExistsInitializer : CreateDatabaseIfNotExists<TContext>
        {
            public CreateDatabaseIfNotExistsInitializer()
            {

            }
            public override void InitializeDatabase(TContext context)
            {
                //    //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                //, string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

                try
                {
                    base.InitializeDatabase(context);
                }
                catch (Exception ex)
                {

                    //if(context.Database.Connection.State == System.Data.ConnectionState.Closed)
                    context.Database.KillConnectionsToTheDatabase();
                    base.InitializeDatabase(context);
                    //throw new Exception(ex.Error(MethodBase.GetCurrentMethod()), ex);
                }
            }
            protected override void Seed(TContext context)
            {
                //context.Seed(context);
                base.Seed(context);
            }
        }
        public class DropCreateAlwaysInitializer : DropCreateDatabaseAlways<TContext>
        {
            public DropCreateAlwaysInitializer()
            {

            }
            public override void InitializeDatabase(TContext context)
            {
                //    //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                //, string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

                try
                {
                    base.InitializeDatabase(context);
                }
                catch (Exception ex)
                {

                    //if(context.Database.Connection.State == System.Data.ConnectionState.Closed)
                    context.Database.KillConnectionsToTheDatabase();
                    base.InitializeDatabase(context);
                    //throw new Exception(ex.Error(MethodBase.GetCurrentMethod()), ex);
                }
            }

            protected override void Seed(TContext context)
            {
                //context.Seed(context);
                base.Seed(context);
            }
        }
        public class DropCreateDatabaseIfModelChangesInitializer : DropCreateDatabaseIfModelChanges<TContext>
        {
            public DropCreateDatabaseIfModelChangesInitializer()
            {

            }
            public override void InitializeDatabase(TContext context)
            {
                //    //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                //, string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

                try
                {
                    base.InitializeDatabase(context);
                }
                catch (Exception ex)
                {

                    if (context.Database.Connection.State == System.Data.ConnectionState.Closed)
                        context.Database.KillConnectionsToTheDatabase();
                    base.InitializeDatabase(context);
                    throw new Exception(ex.Error(MethodBase.GetCurrentMethod()), ex);
                }
            }
            protected override void Seed(TContext context)
            {
                base.Seed(context);
                //context.Seed(context);
            }
        }

        //public class MigrateDatabaseToLatestVersionInitializer<TContext, TMigrationsConfiguration>
        //    : MigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration> 
        //    //, IDatabaseInitializer<TContext>
        //    where TContext : DbContext
        //    where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        //{
        //    MigrateDatabaseToLatestVersionInitializer()
        //        : base()
        //    {
        //    }
        //    MigrateDatabaseToLatestVersionInitializer(bool useSuppliedContext)
        //         : base(useSuppliedContext)
        //    {
        //    }
        //    MigrateDatabaseToLatestVersionInitializer(string connectionStringName)
        //        : base(connectionStringName)
        //    {
        //    }
        //    MigrateDatabaseToLatestVersionInitializer(bool useSuppliedContext, TMigrationsConfiguration configuration)
        //        : base(useSuppliedContext, configuration)
        //    {
        //    }
        //}

        private static bool CheckDatabaseExists(SqlConnection tmpConn, string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                tmpConn = new SqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes");

                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);

                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        tmpConn.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        public static bool CheckDatabaseExists(string connectionString, string databaseName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection))
                {
                    connection.Open();
                    return (command.ExecuteScalar() != DBNull.Value);
                }
            }
        }

        public static DbContext GetDbContextFromEntity(object entity)
        {
            var object_context = GetObjectContextFromEntity(entity);

            if (object_context == null || object_context.TransactionHandler == null)
                return null;

            return object_context.TransactionHandler.DbContext;
        }
        private static ObjectContext GetObjectContextFromEntity(object entity)
        {
            var field = entity.GetType().GetField("_entityWrapper");

            if (field == null)
                return null;

            var wrapper = field.GetValue(entity);
            var property = wrapper.GetType().GetProperty("Context");
            var context = (ObjectContext)property.GetValue(wrapper, null);

            return context;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        //protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        //{
        //    return base.ShouldValidateEntity(entityEntry);
        //}
        //protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        //{
        //    return base.ValidateEntity(entityEntry, items);
        //}

        //private void auditFields()
        //{
        //    // var auditUser = User.Identity.Name; // in web apps
        //    var auditDate = DateTime.Now;
        //    foreach (var entry in this.ChangeTracker.Entries<BaseEntity>())
        //    {
        //        // Note: You must add a reference to assembly : System.Data.Entity
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedOnEn = auditDate;
        //                entry.Entity.ModifiedOnEn = auditDate;
        //                entry.Entity.CreatedBy = "Admin";
        //                entry.Entity.ModifiedBy = "Admin";
        //                break;

        //            case EntityState.Modified:
        //                entry.Entity.ModifiedOnEn = auditDate;
        //                entry.Entity.ModifiedBy = "Admin";
        //                break;
        //        }
        //    }
        //}
        //public void RejectChanges()
        //{
        //    foreach (var entry in this.ChangeTracker.Entries())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Modified:
        //                entry.State = EntityState.Unchanged;
        //                break;

        //            case EntityState.Added:
        //                entry.State = EntityState.Detached;
        //                break;
        //        }
        //    }
        //}
        public override int SaveChanges()
        {
            // applyCorrectYeKe();
            // auditFields();
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //var errorMessages = ex.EntityValidationErrors
                //    .SelectMany(x => x.ValidationErrors)
                //    .Select(x => x.ErrorMessage);

                //// Join the list to a single string.
                //var fullErrorMessage = string.Join(" ; ", errorMessages);

                //// Combine the original exception message with the new one.
                //var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                //// Throw a new DbEntityValidationException with the improved exception message.
                //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

                throw new Exception(ex.Error(MethodBase.GetCurrentMethod()), ex);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //بررسی مورد اول
                var dbEntityEntry = ex.Entries.First();
                var dbPropertyValues = dbEntityEntry.GetDatabaseValues();
                //ErrorSignal.FromCurrentContext().Raise(ex);
                //ClsLog.ErrLog(ex, MethodBase.GetCurrentMethod());
                throw new Exception(ex.Error(MethodBase.GetCurrentMethod()), ex);
                throw (ex.InnerException != null ? ex.InnerException : ex);
            }
            catch (DbUpdateException ex)
            {
                //ErrorSignal.FromCurrentContext().Raise(ex);
                //ClsLog.ErrLog(ex, MethodBase.GetCurrentMethod());

                throw new Exception(ex.Error(MethodBase.GetCurrentMethod()), ex);
                throw (ex.InnerException != null ? ex.InnerException : ex);
            }
            catch (NotSupportedException ex)
            {
                //ErrorSignal.FromCurrentContext().Raise(ex);
                //ClsLog.ErrLog(ex, MethodBase.GetCurrentMethod());
                throw (ex.InnerException != null ? ex.InnerException : ex);
            }
            catch (ObjectDisposedException ex)
            {
                //ErrorSignal.FromCurrentContext().Raise(ex);
                //ClsLog.ErrLog(ex, MethodBase.GetCurrentMethod());
                throw (ex.InnerException != null ? ex.InnerException : ex);
            }
            catch (TypeInitializationException ex)
            {
                //ErrorSignal.FromCurrentContext().Raise(ex);
                //ClsLog.ErrLog(ex, MethodBase.GetCurrentMethod());
                throw (ex.InnerException != null ? ex.InnerException : ex);
            }
            catch (InvalidOperationException ex)
            {
                //ErrorSignal.FromCurrentContext().Raise(ex);
                //ClsLog.ErrLog(ex, MethodBase.GetCurrentMethod());
                throw (ex.InnerException != null ? ex.InnerException : ex);
            }
            catch (Exception ex)
            {
                //ErrorSignal.FromCurrentContext().Raise(ex);
                //ClsLog.ErrLog(ex, MethodBase.GetCurrentMethod());
                throw (ex.InnerException != null ? ex.InnerException : ex);
            }
        }
        //public bool HasChanges()
        //{
        //    foreach (var entry in this.ChangeTracker.Entries())
        //    {
        //        if (entry.State == EntityState.Modified || entry.State = EntityState.Added)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //private void applyCorrectYeKe()
        //{
        //    //پیدا کردن موجودیت‌های تغییر کرده
        //    var changedEntities = this.ChangeTracker
        //                              .Entries()
        //                              .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

        //    foreach (var item in changedEntities)
        //    {
        //        if (item.Entity == null) continue;

        //        //یافتن خواص قابل تنظیم و رشته‌ای این موجودیت‌ها
        //        var propertyInfos = item.Entity.GetType().GetProperties(
        //            BindingFlags.Public | BindingFlags.Instance
        //            ).Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

        //        var pr = new PropertyReflector();

        //        //اعمال یکپارچگی نهایی
        //        foreach (var propertyInfo in propertyInfos)
        //        {
        //            var propName = propertyInfo.Name;
        //            var val = pr.GetValue(item.Entity, propName);
        //            if (val != null)
        //            {
        //                var newVal = val.ToString().Replace("ی", "ی").Replace("ک", "ک");
        //                if (newVal == val.ToString()) continue;
        //                pr.SetValue(item.Entity, propName, newVal);
        //            }
        //        }
        //    }
        //}

        #region IUnitOfWork Members
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        #endregion
        //public int SaveAllChanges(bool invalidateCacheDependencies)
        //{
        //    return SaveChanges(invalidateCacheDependencies);
        //}
        //public async Task<int> SaveAllChangesAsync(bool invalidateCacheDependencies)
        //{
        //    return await SaveChangesAsync(invalidateCacheDependencies);
        //}

        //public int SaveChanges(bool invalidateCacheDependencies)
        //{
        //    var changedEntityNames = this.GetChangedEntityNames();
        //    var result = base.SaveChanges();
        //    if (invalidateCacheDependencies)
        //    {
        //        new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
        //    }
        //    return result;
        //}

        //public async Task<int> SaveChangesAsync(bool invalidateCacheDependencies)
        //{
        //    var changedEntityNames = this.GetChangedEntityNames();
        //    var result = await base.SaveChangesAsync();
        //    if (invalidateCacheDependencies)
        //    {
        //        new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
        //    }
        //    return result;
        //}


        //public void MarkAsAdded<TEntity>(TEntity entity) where TEntity : class
        //{
        //    Entry(entity).State = EntityState.Added;
        //}
        //public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        //{
        //    Entry(entity).State = EntityState.Deleted;
        //}

        //public IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        //{
        //    return ((DbSet<TEntity>)this.Set<TEntity>()).AddRange(entities);
        //}

        //public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        //{
        //    Entry(entity).State = EntityState.Modified;
        //}

        //public IList<T> GetRows<T>(string sql, params object[] parameters) where T : class
        //{
        //    return Database.SqlQuery<T>(sql, parameters).ToList();
        //}

        //public void ForceDatabaseInitialize()
        //{
        //    this.Database.Initialize(force: true);
        //}

    }
    //static public class ExtendedMetod
    //{
    //    public static string Error(this DbEntityValidationException ex, MethodBase mb = null)
    //    {
    //        var Err = new StringBuilder();
    //        Err.AppendLine(String.Format(">>Err [{0:D6}]: {1} - {2}{3}{4}\n",
    //            1,
    //            mb.DeclaringType.ToString(),
    //            new StackTrace(new StackFrame(1)).GetFrame(0).GetMethod().ToString(),
    //            "",
    //            "\n>>\t" + ExceptionToString(ex) + "\n>>\t{\n>>\t" + ex.StackTrace.Replace("\n", "\n>>\t") + "\n>>\t}"));
    //        Err.AppendLine();
    //        foreach (var error in ex.EntityValidationErrors)
    //        {
    //            var entry = error.Entry;
    //            foreach (var err in error.ValidationErrors)
    //            {
    //                Err.AppendLine(err.PropertyName + " " + err.ErrorMessage);
    //            }
    //            Err.AppendLine();
    //            foreach (PropertyInfo propertyInfo in entry.Entity.GetType().GetProperties())
    //            {
    //                string st = "";
    //                st = propertyInfo.ToString();
    //                st += " = ";
    //                var tObj = GetPropValue(entry.Entity, propertyInfo.Name);
    //                st += (GetPropValue(entry.Entity, propertyInfo.Name) != null ? GetPropValue(entry.Entity, propertyInfo.Name).ToString() : "Null");
    //                Err.AppendLine(st);
    //            }
    //        }

    //        return Err.ToString();
    //    }
    //    public static object GetPropValue(object src, string propName)
    //    {
    //        return src.GetType().GetRuntimeProperty(propName).GetValue(src);
    //    }
    //    public static string ExceptionToString(Exception ex)
    //    {
    //        StringBuilder errorMsg = new StringBuilder();
    //        for (Exception current = ex; current != null; current = current.InnerException)
    //        {
    //            if (errorMsg.Length > 0)
    //                errorMsg.Append("\n");
    //            errorMsg.Append(current.Message.
    //                Replace("See the inner exception for details.", string.Empty));
    //        }
    //        errorMsg.Replace("\n", "\n>>\t");
    //        return errorMsg.ToString();
    //    }

    //}

}
