using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.ExtensionMethods
{
    static public class ExtensionException
    {
        public static string Error(this Exception ex, MethodBase mb = null)
        {
            var Err = new StringBuilder();
            Err.AppendLine(String.Format(">>Err [{0:D6}]: {1} - {2}{3}{4}\n",
                1,
                mb.DeclaringType.ToString(),
                new StackTrace(new StackFrame(1)).GetFrame(0).GetMethod().ToString(),
                ""/*msg*/,
                "\n>>\t" + ExceptionToString(ex) + "\n>>\t{\n>>\t" + ex.StackTrace.Replace("\n", "\n>>\t") + "\n>>\t}"));
            return Err.ToString();
        }
        public static string Error(this NotSupportedException ex, MethodBase mb = null)
        {
            return Error((Exception)ex, mb);
        }
        public static string Error(this ObjectDisposedException ex, MethodBase mb = null)
        {
            return Error((Exception)ex, mb);
        }
        public static string Error(this TypeInitializationException ex, MethodBase mb = null)
        {
            return Error((Exception)ex, mb);
        }
        public static string Error(this InvalidOperationException ex, MethodBase mb = null)
        {
            return Error((Exception)ex, mb);
        }

        public static object GetPropValue(this object src, string propName)
        {
            return src.GetType().GetRuntimeProperty(propName).GetValue(src);
        }
        public static string ExceptionToString(this Exception ex)
        {
            StringBuilder errorMsg = new StringBuilder();
            for (Exception current = ex; current != null; current = current.InnerException)
            {
                if (errorMsg.Length > 0)
                    errorMsg.Append("\n");
                errorMsg.Append(current.Message.
                    Replace("See the inner exception for details.", string.Empty));
            }
            errorMsg.Replace("\n", "\n>>\t");
            return errorMsg.ToString();
        }
    }
}
