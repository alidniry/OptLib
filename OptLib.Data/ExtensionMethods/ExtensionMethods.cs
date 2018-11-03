using OptLib.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptLib.Globalization.ExtensionMethods;
using System.Data.Entity;
using System.Data;
using OptLib.Data.ComplexType;

namespace OptLib.Data.ExtensionMethods
{
    public static partial class Extensions
    {
        public static string GetPersianDateHistoryCreate(this _History history)
        {
            return history.CreateDate.GregorianToPersian();
        }
        public static string GetPersianDateHistoryLastChanges(this _History history)
        {
            return history.LastChangesDate.GregorianToPersian();
        }
        public static string GetPersianDateHistoryDel(this _History history)
        {
            return history.DeleteDate?.GregorianToPersian();
        }

        public static void SetPersianDateHistoryCreate(this _History history, string date)
        {
            history.CreateDate = date.PersianToGregorian();
        }
        public static void SetPersianDateHistoryLastChanges(this _History history, string date)
        {
            history.LastChangesDate = date.PersianToGregorian();
        }
        public static void SetPersianDateHistoryDel(this _History history, string date)
        {
            history.DeleteDate = date.PersianToGregorian();
        }

    }
    public static partial class ExtensionsDatabase
    {
        public static void KillConnectionsToTheDatabase(this Database database)
        {
            var databaseName = database.Connection.Database;
            const string sqlFormat = @"
             USE master; 

             DECLARE @databaseName VARCHAR(50);
             SET @databaseName = '{0}';

             declare @kill varchar(8000) = '';
             select @kill=@kill+'kill ' + convert(varchar(5),spid) +';'
             from master..sysprocesses 
             where dbid=db_id(@databaseName);

             exec (@kill);";

            var sql = string.Format(sqlFormat, databaseName);
            using (var command = database.Connection.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                command.Connection.Open();

                command.ExecuteNonQuery();

                command.Connection.Close();
            }
        }
    }
}
