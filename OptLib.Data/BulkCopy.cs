using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Optlib.Data.BulkCopy.Mapping;
using OptLib.Data;
using OptLib.Data.Base;
using OptLib.Data.ExtensionMethods;

namespace Optlib.Data.BulkCopy
{
    public class ThresholdReachedEventArgs : EventArgs
    {
        public string TableName { get; set; }
        public long CountRows { get; set; }
        public long ReadRows { get; set; }
        public long WriteRows { get; set; }
        public TimeSpan TimePross { get; set; }
        public DateTime StartTime { get; set; }
    }

    public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e);

    public class BulkCopy<TDbConnection, TDbCommand> : IDisposable
         where TDbConnection : DbConnection, new()
         where TDbCommand : DbCommand, new()
    {
        public delegate List<TEntityOutput> SimpleDelegate<TEntityInput, TEntityOutput>(IEnumerable<TEntityInput> list);
        public event ThresholdReachedEventHandler ThresholdReached;

        public int PagePaging { get; set; } = 100000;
        public int NotifyAfter { get; set; } = 50000;
        public int BatchSize { get; set; } = 20000;
        public int BulkCopyTimeout { get; set; } = 0;

        public long RowReads { get; set; } = 0;
        public long RowWrites { get; set; } = 0;
        public string ConnectionStringInput { get; set; } = null;
        public string ConnectionStringOutput { get; set; } = null;
        private TDbConnection Connection { get; set; } = new TDbConnection();

        //public SimpleDelegate<TEntity> MyProperty { get; set; }
        public BulkCopy()
        {
            Open();
        }

        public BulkCopy(string connectionStringInput, string connectionStringOutput)
            //: this()
        {
            this.ConnectionStringInput = connectionStringInput;
            this.ConnectionStringOutput = connectionStringOutput;

            Open();
        }
        public void Open()
        {
            if (this.ConnectionStringInput != null && this.ConnectionStringOutput != null)
            {
                this.Connection.ConnectionString = this.ConnectionStringInput;
                this.Connection.Open();
            }
        }
        //protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        //{
        //    ThresholdReachedEventHandler handler = ThresholdReached;
        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //}
        private ThresholdReachedEventArgs EventData = null;
        public Response FullCopyTable<TEntityInput, TEntityOutput>(string tableName, string command, SimpleDelegate<TEntityInput, TEntityOutput> action)
            where TEntityInput : class, new()
            where TEntityOutput : class, new()
        {
            var count = Count(tableName);
            var reads = 0;
            //ThresholdReachedEventHandler handler = ThresholdReached;
            var startTime = DateTime.Now;
            RowReads = 0;

            EventData = new ThresholdReachedEventArgs() { TableName = tableName, StartTime = startTime, CountRows = count };
            var cmd = new TDbCommand();
            cmd.Connection = this.Connection;
            cmd.CommandText = command;
            cmd.CommandTimeout = 0;

            using (var reader = cmd.ExecuteReader())
            {
                if (reader == null) throw new ArgumentNullException("dataReader");

                if (!reader.HasRows) return null;

                var bulkCopy = new SqlBulkCopy(ConnectionStringOutput, SqlBulkCopyOptions.KeepNulls & SqlBulkCopyOptions.KeepIdentity)
                {
                    DestinationTableName = tableName,
                    BulkCopyTimeout = this.BulkCopyTimeout,
                    BatchSize = this.BatchSize,
                    //EnableStreaming,
                    NotifyAfter = this.NotifyAfter,
                    //ColumnMappings
                };
                bulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);
                new TEntityOutput().GetColumnMapping().ForEach(delegate (SqlBulkCopyColumnMapping item) { bulkCopy.ColumnMappings.Add(item); });


                var IsReader = true;
                while (reads < count)
                {
                    var result = new List<TEntityInput>();
                    //var rows = new List<IDictionary<string, object>>();
                    for (int i = 0; i < PagePaging; i++)
                    {
                        if (reads < count)
                        {
                            if (i % this.NotifyAfter == 0)
                            {
                                EventData.ReadRows = reads;
                                EventData.TimePross = DateTime.Now - startTime;
                                ThresholdReached(this, EventData);//OnThresholdReached(EventData);
                            }

                            IsReader = reader.Read();
                            result.Add(BuildEntity1<TEntityInput>(reader));
                            //rows.Add(ReadRow(reader));
                            reads++;
                        }
                    }
                    //foreach (var row in rows)
                    //{
                    //    result.Add(BuildEntity<TEntityInput>(row));
                    //}
                    EventData.ReadRows = reads;
                    EventData.TimePross = DateTime.Now - startTime;
                    ThresholdReached(this, EventData);//OnThresholdReached(EventData);
                    List<TEntityOutput> models = action.Invoke(result);


                    //var t = models.MapModel(tableName);
                    try
                    {
                        var tDataTable = models.ConvertToDataTable();
                        bulkCopy.WriteToServer(tDataTable);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }







                //columnMapping.ForEach(delegate (SqlBulkCopyColumnMapping item) { bulkCopy.ColumnMappings.Add(item); });
                //var tDataTable = ClsExtendedLibrary.ConvertToDataTable<TEntity>(entity);
                //bulkCopy.BulkCopyTimeout = 0;




            }
            //IEnumerable<TEntity> models = new List<TEntity>();
            //DataTable table = models.MapModel(tableName);

            var endTime = DateTime.Now;
            EventData.TimePross = DateTime.Now - EventData.StartTime;
            EventData.WriteRows = EventData.CountRows;
            ThresholdReached(this, EventData);//OnThresholdReached(EventData);
            return new Response(EventData.TableName , startTime, endTime, EventData.CountRows);
        }
        public class Response
        {
            public Response(string tableName, DateTime start, DateTime end, long count)
            {
                this.TableName = tableName;
                this.ProcessTime = end - start;
                this.CountRows = count;
            }
            public TimeSpan ProcessTime { get; set; }
            public long CountRows { get; set; }
            public string TableName { get; set; }

            public override string ToString() { return $"Table : { this.TableName } ( Count = { this.CountRows }) In Time = { this.ProcessTime } \r\n"; }
        }

        private void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            EventData.TimePross = DateTime.Now - EventData.StartTime;
            EventData.WriteRows += NotifyAfter;
            ThresholdReached(this, EventData);
        }

        private TEntity BuildEntity1<TEntity>(IDataRecord record)
            where TEntity : class, new()
        {
            var entity = new TEntity();
            for (int i = 0; i < record.FieldCount; i++)
            {
                object value = null;
                if (record.GetValue(i) == DBNull.Value)
                    value = null;
                else
                    value = record.GetValue(i);

                var property = /*_type*/ typeof(TEntity).GetProperty(record.GetName(i), BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (property != null && property.CanWrite)
                {
                    try
                    {
                        property.SetValue(entity, value, null);
                    }
                    catch (Exception ex)
                    {
                        Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                        object safeValue = (value == null) ? null : Convert.ChangeType(value, t);

                        property.SetValue(entity, safeValue, null);

                    }

                }
                //SetProperty(record.GetName(i), entity, record.GetValue(i));
            }

            return entity;
        }

        public void bulCopy<TEntity>(SqlConnection conn, List<TEntity> entity, List<SqlBulkCopyColumnMapping> columnMapping, string tableName)
            where TEntity : class, new()
        {
            var bulkCopy = new SqlBulkCopy(conn.ConnectionString, SqlBulkCopyOptions.KeepNulls & SqlBulkCopyOptions.KeepIdentity)
            {
                DestinationTableName = tableName,
            };

            columnMapping.ForEach(delegate (SqlBulkCopyColumnMapping item) { bulkCopy.ColumnMappings.Add(item); });

            var tDataTable = entity.ConvertToDataTable<TEntity>();

            bulkCopy.BulkCopyTimeout = 0;
            bulkCopy.WriteToServer(tDataTable);
        }
        public void bulCopy<TEntity>(SqlConnection conn, List<TEntity> entity, string tableName)
            where TEntity : _Entity
        {
            var bulkCopy = new SqlBulkCopy(conn.ConnectionString)
            {
                DestinationTableName = tableName,/*"[Identity]",*/
            };

            //entity[0]?.ColumnMapping.ForEach(delegate (SqlBulkCopyColumnMapping item) { bulkCopy.ColumnMappings.Add(item); });

            var tDataTable = entity.ConvertToDataTable<TEntity>();
            //bulkCopy.DestinationTableName = "[Quiddity].[QdtQuiddity]";
            bulkCopy.BulkCopyTimeout = 0;
            bulkCopy.WriteToServer(tDataTable);
        }







        //private IDictionary<string, object> ReadRow(IDataRecord record)
        //{
        //    var row = new Dictionary<string, object>();
        //    for (int i = 0; i < record.FieldCount; i++)
        //    {
        //        row.Add(record.GetName(i), record.GetValue(i));
        //    }
        //    return row;
        //}
        //private TEntity BuildEntity<TEntity>(IDictionary<string, object> row)
        //    where TEntity : class, new()
        //{
        //    var entity = new TEntity();

        //    foreach (var item in row)
        //    {
        //        var key = item.Key;
        //        var value = item.Value;
        //        if (value == DBNull.Value) value = null; //may be DBNull

        //        SetProperty(key, entity, value);
        //    }

        //    return entity;
        //}

        public void Dispose()
        {
            this.Connection.Close();
            this.Connection.Dispose();
            this.Connection = null;
        }


        public long Count(string tableName)
        {
            var cmd = new TDbCommand();
            cmd.CommandText = $"SELECT Count(*) FROM { tableName }";
            cmd.Connection = this.Connection;
            cmd.CommandTimeout = 50000;

            using (var reader = cmd.ExecuteReader())
            {
                var hasRows = reader.HasRows;
                while (reader.Read())
                {
                    return long.Parse(reader[0].ToString());
                }
            }
            return 0;
        }

        //#region Reflect into entity
        ////private Type _type = typeof(TEntity);
        //private IDictionary<string, MemberInfo> _properties = new Dictionary<string, MemberInfo>();
        //private void SetProperty<TEntity>(string key, TEntity entity, object value)
        //{
        //    //first try dictionary
        //    if (_properties.ContainsKey(key))
        //    {
        //        SetPropertyFromDictionary(_properties[key], entity, value);
        //        return;
        //    }

        //    //otherwise (should be first time only) reflect it out
        //    //first look for a writeable public property of any case
        //    var property = /*_type*/ typeof(TEntity).GetProperty(key,
        //        BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
        //    if (property != null && property.CanWrite)
        //    {
        //        _properties.Add(key, property);
        //        //switch (Type.GetTypeCode(property.PropertyType))
        //        //{
        //        //    case TypeCode.Boolean:
        //        //        property.SetValue(entity, (bool)value, null);
        //        //        break;
        //        //    case TypeCode.Decimal:
        //        //        property.SetValue(entity, (bool)value, null);
        //        //        break;
        //        //    default:
        //        //        break;
        //        //}
        //        try
        //        {
        //            property.SetValue(entity, value, null);
        //        }
        //        catch (Exception ex)
        //        {
        //            Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

        //            object safeValue = (value == null) ? null : Convert.ChangeType(value, t);

        //            property.SetValue(entity, safeValue, null);

        //        }


        //        return;
        //    }

        //    //look for a nonpublic field with the standard _prefix
        //    var field = /*_type*/ typeof(TEntity).GetField("_" + key,
        //        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
        //    _properties.Add(key, field);
        //    field.SetValue(entity, value);
        //}

        //private void SetPropertyFromDictionary<TEntity>(MemberInfo member, TEntity entity, object value)
        //{
        //    var property = member as PropertyInfo;
        //    if (property != null)
        //        try
        //        {
        //            property.SetValue(entity, value, null);
        //        }
        //        catch (Exception ex)
        //        {
        //            Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

        //            object safeValue = (value == null) ? null : Convert.ChangeType(value, t);

        //            property.SetValue(entity, safeValue, null);

        //        }
        //    var field = member as FieldInfo;
        //    if (field != null)
        //        field.SetValue(entity, value);
        //}
        //#endregion
    }

}
namespace Optlib.Data.BulkCopy.Mapping
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ModelMapAttribute : Attribute
    {
        #region Fields  
        private string columnName;
        #endregion
        #region Properties  
        public string ColumnName
        {
            get
            {
                return this.columnName;
            }
            set
            {
                this.columnName = value;
            }
        }
        #endregion
        #region Constructors  
        public ModelMapAttribute(string columnName = null)
        {
            this.columnName = String.IsNullOrWhiteSpace(columnName) ? null : columnName;
        }
        #endregion
    }
    public static class ModelMapper
    {
        public static List<SqlBulkCopyColumnMapping> GetColumnMapping<T>(this T entity)
            where T : class, new()
        {
            if (entity == null /*|| !entity.Any()*/)
            {
                return null;
            }
            else
            {
                List<SqlBulkCopyColumnMapping> result = new List<SqlBulkCopyColumnMapping>();
                IEnumerable<PropertyInfo> propertyInfos = typeof(T).GetProperties().Where(p => p.GetCustomAttributes(typeof(ModelMapAttribute), false).Any());


                //Dictionary<string, string> _dict = new Dictionary<string, string>();

                //PropertyInfo[] props = typeof(T).GetProperties();
                //foreach (PropertyInfo prop in props)
                //{
                //    object[] attrs = prop.GetCustomAttributes(true);
                //    foreach (object attr in attrs)
                //    {
                //        ModelMapAttribute authAttr = attr as ModelMapAttribute;
                //        if (authAttr != null)
                //        {
                //            string propName = prop.Name;
                //            string auth = authAttr.ColumnName;

                //            _dict.Add(propName, auth);
                //        }
                //    }
                //}
                //Create columns  
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    ModelMapAttribute attribute = propertyInfo.GetCustomAttributes(typeof(ModelMapAttribute), true).First() as ModelMapAttribute;
                    if (!String.IsNullOrWhiteSpace(attribute.ColumnName))
                    {
                        result.Add(new SqlBulkCopyColumnMapping(propertyInfo.Name, attribute.ColumnName));
                    }
                    else
                    {
                        result.Add(new SqlBulkCopyColumnMapping(propertyInfo.Name, propertyInfo.Name));
                    }
                }
                return result;
            }
        }

        public static DataTable MapModel<T>(this List<T> models, String tableName)
            where T : class, new()
        {
            return ToDataTable(models, tableName);
        }
        public static DataTable MapModel<T>(this IEnumerable<T> models, String tableName)
            where T : class, new()
        {
            return ToDataTable(models, tableName);
        }
        public static DataTable ToDataTable<T>(IEnumerable<T> models, String tableName) 
            where T : class, new()
        {
            if (models == null || !models.Any())
            {
                return null;
            }
            else
            {
                DataTable result = new DataTable(tableName);
                IEnumerable<PropertyInfo> propertyInfos = typeof(T).GetProperties().Where(p => p.GetCustomAttributes(typeof(ModelMapAttribute), true).Any());
                //Create columns  
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    ModelMapAttribute attribute = propertyInfo.GetCustomAttributes(typeof(ModelMapAttribute), true).First() as ModelMapAttribute;
                    if (!String.IsNullOrWhiteSpace(attribute.ColumnName))
                    {
                        result.Columns.Add(attribute.ColumnName);
                    }
                    else
                    {
                        result.Columns.Add(propertyInfo.Name);
                    }
                }

                //Fill the data  
                foreach (var model in models)
                {
                    int matchCount = 0;
                    DataRow row = result.NewRow();
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        ModelMapAttribute attribute = propertyInfo.GetCustomAttributes(typeof(ModelMapAttribute), true).First() as ModelMapAttribute;
                        Object value = propertyInfo.GetValue(model);
                        row[!String.IsNullOrWhiteSpace(attribute.ColumnName) ? attribute.ColumnName : propertyInfo.Name] = value;

                        if (value != null)
                        {
                            matchCount++;
                        }
                    }

                    //Skip empty models  
                    if (matchCount > 0)
                    {
                        result.Rows.Add(row);
                    }
                }
                result.AcceptChanges();
                return result;
            }
        }
    }
}  
