using OptLib.Data.Helper.EntitiesReflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.Data.ExtensionMethods
{
    public static class DBs
    {
        public static DataTable ConvertToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static bool IsValidInSqlServer(this DateTime? date)
        {
            if (date != null && (date < new DateTime(1753, 1, 1) || date > new DateTime(9999, 12, 31)))
                return false;
            else
                return true;
        }
        public static IList<TEntity> SQLEntityFiller<TEntity>(this SqlCommand cmd)
            where TEntity : class, new()
        {
            IList<TEntity> list;
            using (cmd)
            {
                cmd.CommandTimeout = 0;
                var t = new EntityFiller<TEntity>();
                using (var reader = cmd.ExecuteReader())
                {
                    list = t.Fill(reader);
                }
            }
            return list;
        }
        public static void DelItem(this SqlConnection conn, string[] Ids, string tableName, string fealdName = "Id", bool keyTypeIsString = true)
        {
            var tIds = Ids.Select(p => p).ToArray();
            for (int i = 0; i < tIds.Count(); i++)
            {
                if (keyTypeIsString == true)
                    tIds[i] = $"{fealdName} LIKE '{ tIds[i] }'";
                else
                    tIds[i] = $"{fealdName}={ tIds[i] }";
            }
            var ttt = string.Join(" OR ", tIds);
            var delString = $"DELETE FROM { tableName } WHERE { ttt };";
            //var conn = new SqlConnection(context.Database.Connection.ConnectionString);
            conn.Open();
            var cmd = new SqlCommand(delString, conn);
            cmd.ExecuteNonQuery();
        }
        public static long MaxItem(this SqlConnection conn, string tableName, string fealdName = "Id")
        {
            var maxString = $"SELECT { fealdName } FROM  { tableName } WHERE { fealdName } = (SELECT MAX({ fealdName }) FROM { tableName });";
            //conn.Open();
            var cmd = new SqlCommand(maxString, conn);
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
    }
}
