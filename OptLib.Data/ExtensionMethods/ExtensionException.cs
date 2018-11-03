using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OptLib.ExtensionMethods;

namespace OptLib.Data.ExtensionMethods
{
    public static class ExtensionException
    {
        public static string Error(this DbEntityValidationException ex, MethodBase mb = null)
        {
            var Err = new StringBuilder();
            Err.AppendLine(String.Format(">>Err [{0:D6}]: {1} - {2}{3}{4}\n",
                1,
                mb.DeclaringType.ToString(),
                new StackTrace(new StackFrame(1)).GetFrame(0).GetMethod().ToString(),
                "",
                "\n>>\t" + ex.ExceptionToString() + "\n>>\t{\n>>\t" + ex.StackTrace.Replace("\n", "\n>>\t") + "\n>>\t}"));
            Err.AppendLine();
            foreach (var error in ex.EntityValidationErrors)
            {
                var entry = error.Entry;
                foreach (var err in error.ValidationErrors)
                {
                    Err.AppendLine(err.PropertyName + " " + err.ErrorMessage);
                }
                Err.AppendLine();
                foreach (PropertyInfo propertyInfo in entry.Entity.GetType().GetProperties())
                {
                    string st = "";
                    st = propertyInfo.ToString();
                    st += " = ";
                    var tObj = entry.Entity.GetPropValue(propertyInfo.Name);
                    st += (entry.Entity.GetPropValue(propertyInfo.Name) != null ? entry.Entity.GetPropValue(propertyInfo.Name).ToString() : "Null");
                    Err.AppendLine(st);
                }
            }

            return Err.ToString();
        }
        public static string Error(this DbUpdateException ex, MethodBase mb = null)
        {
            var Err = new StringBuilder();
            Err.AppendLine(String.Format(">>Err [{0:D6}]: {1} - {2}{3}{4}{5}",
                1,
                mb.DeclaringType.ToString(),
                new StackTrace(new StackFrame(1)).GetFrame(0).GetMethod().ToString(),
                /*msg*/"",
                "\n>>\t" + ex.ExceptionToString() + "\n>>\t{\n>>\t" + ex.StackTrace.Replace("\n", "\n>>\t") + "\n>>\t}",
                "\n>>\t" + ExceptionHelper.CreateFromDbUpdateException((DbUpdateException)ex).Message));
            Err.AppendLine(">>\t");
            foreach (var entry in ex.Entries)
            {
                foreach (PropertyInfo propertyInfo in entry.Entity.GetType().GetProperties())
                {
                    string st = "";
                    st = propertyInfo.ToString();
                    st += " = ";
                    //var tObj = GetPropValue(entry.Entity, propertyInfo.Name);
                    st += (entry.Entity.GetPropValue(propertyInfo.Name) != null ? entry.Entity.GetPropValue(propertyInfo.Name).ToString() : "Null");
                    Err.AppendLine(">>\t" + st);
                }
            }
            Err.AppendLine();
            return Err.ToString();
        }
        public static string Error(this DbUpdateConcurrencyException ex, MethodBase mb = null)
        {
            return Error((DbUpdateException)ex, mb);
        }

    }
}
