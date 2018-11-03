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
//using TRDc.ExtensionException;

namespace QptLib.Data
{
    public partial class BaseContext 
        : DbContext, IDisposable, IObjectContextAdapter
    {
        protected BaseContext()
            : base()
        {

        }
        protected BaseContext(DbCompiledModel model)
            : base(model)
        {

        }

        public BaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        public BaseContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {

        }
        public BaseContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
        public BaseContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {

        }
        public BaseContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {

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
