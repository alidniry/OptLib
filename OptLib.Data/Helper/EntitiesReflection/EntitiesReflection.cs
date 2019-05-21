using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


//public void TestEntityFiller()
//{
////test requires Northwind on SqlExpress.
//string connectionString = @"Data Source=.\SQLEXPRESS;Integrated Security=true;Initial Catalog=Northwind";
//string sql = "SELECT [CategoryID], [CategoryName], [Description], [Picture] FROM Categories";
//IList<Category> list;
//using (var con = new SqlConnection(connectionString))
//{
//using (var cmd = new SqlCommand(sql, con))
//{
//con.Open();
//var t = new EntityFiller<Category>();
//using (var reader = cmd.ExecuteReader())
//{
//list = t.Fill(reader);
//}
//}
//}

//Assert.AreEqual(8, list.Count, "Northwind has 8 categories");
//}

//public class Category
//{
//    private int _categoryId;
//    public int CategoryID
//    {
//        get { return _categoryId; }
//    }
//    public string CategoryName { get; set; }
//    public string Description { get; set; }
//    //public byte[] Picture { get; set; }
//}
namespace OptLib.Data.Helper.EntitiesReflection
{
    /// <summary>
    /// Reads data reader into a list of entities
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class EntityFiller<TEntity>
            where TEntity : new() //must have public parameterless constructor
    {
        //a dictionary of all properties on the entity
        private IDictionary<string, MemberInfo> _properties = new Dictionary<string, MemberInfo>();
        private Type _type = typeof(TEntity);

        /// <summary>
        /// Reads data reader into a list of entities
        /// </summary>
        /// <param name="dataReader">The data reader.</param>
        /// <returns>A list of the specified entities</returns>
        public IList<TEntity> Fill(DbDataReader dataReader)
        {
            if (dataReader == null) throw new ArgumentNullException("dataReader");

            var result = new List<TEntity>();
            if (!dataReader.HasRows) return result;

            //a list of dictionaries for each row
            var rows = new List<IDictionary<string, object>>();
            while (dataReader.Read())
            {
                rows.Add(ReadRow(dataReader));
            }

            //close the dataReader
            dataReader.Close();

            //use the list of dictionaries
            foreach (var row in rows)
            {
                result.Add(BuildEntity(row));
            }

            return result;
        }

        private IDictionary<string, object> ReadRow(IDataRecord record)
        {
            var row = new Dictionary<string, object>();
            for (int i = 0; i < record.FieldCount; i++)
            {
                row.Add(record.GetName(i), record.GetValue(i));
            }
            return row;
        }

        private TEntity BuildEntity(IDictionary<string, object> row)
        {
            var entity = new TEntity();
            var lError = new List<string>();

            foreach (var item in row)
            {
                var key = item.Key;
                var value = item.Value;
                if (value == DBNull.Value) value = null; //may be DBNull

                var err = SetProperty(key, entity, value);
                if (err != null)
                    lError.Add(err);
            }
            //if (lError.Count > 0)
            //    throw new Exception(string.Join(",", lError));
            return entity;
        }

        #region Reflect into entity
        private string SetProperty(string key, TEntity entity, object value)
        {
            //first try dictionary
            if (_properties.ContainsKey(key))
            {
                SetPropertyFromDictionary(_properties[key], entity, value);
                return null;
            }

            //otherwise (should be first time only) reflect it out
            //first look for a writeable public property of any case
            var property = _type.GetProperty(key,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            if (property != null && property.CanWrite)
            {
                _properties.Add(key, property);
                property.SetValue(entity, value, null);
                return null;
            }

            //look for a nonpublic field with the standard _ prefix
            var field = _type.GetField("_" + key,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
            _properties.Add(key, field);
            try
            {
                field.SetValue(entity, value);
            }
            catch (Exception ex)
            {
                return $"{ key } : { value } - { ex.Message }";
            }
            return null;
        }

        private void SetPropertyFromDictionary(MemberInfo member, TEntity entity, object value)
        {
            var property = member as PropertyInfo;
            if (property != null)
                property.SetValue(entity, value, null);
            var field = member as FieldInfo;
            if (field != null)
                field.SetValue(entity, value);
        }
        #endregion
    }
}
