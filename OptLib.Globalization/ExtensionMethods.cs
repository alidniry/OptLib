using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.Globalization.ExtensionMethods
{
    public static class Extensions
    {
        public static string GregorianToPersian(this DateTime date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear(date).ToString("0000/") + pc.GetMonth(date).ToString("00/") + pc.GetDayOfMonth(date).ToString("00");
        }
        public static DateTime PersianToGregorian(this string date)
        {
            return DateTime.Parse(date, new CultureInfo("fa-IR"));
        }
        public static DateTime PersianToGregorian(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, pc);
        }
    }
}
