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
        public static string GregorianToPersianBig(this DateTime date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear(date).ToString("0000/") + pc.GetMonth(date).ToString("00/") + pc.GetDayOfMonth(date).ToString("00") +
                pc.GetHour(date).ToString("00:") + pc.GetMinute(date).ToString("00:") + pc.GetSecond(date).ToString("00");
        }
        public static string GregorianToPersian(this DateTime? date)
        {
            if (date == null)
                return null;
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear((DateTime)date).ToString("0000/") + pc.GetMonth((DateTime)date).ToString("00/") + pc.GetDayOfMonth((DateTime)date).ToString("00");
        }
        public static string GregorianToPersianBig(this DateTime? date)
        {
            if (date == null)
                return null;
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear((DateTime)date).ToString("0000/") + pc.GetMonth((DateTime)date).ToString("00/") + pc.GetDayOfMonth((DateTime)date).ToString("00") +
                pc.GetHour((DateTime)date).ToString("00:") + pc.GetMinute((DateTime)date).ToString("00:") + pc.GetSecond((DateTime)date).ToString("00");
        }

        public static int GregorianToPersian_Year(this DateTime date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear((DateTime)date);
        }
        public static int GregorianToPersian_Month(this DateTime date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetMonth((DateTime)date);
        }
        public static int GregorianToPersian_DayOfMonth(this DateTime date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetDayOfMonth((DateTime)date);
        }

        public static int? GregorianToPersian_Year(this DateTime? date)
        {
            if (date == null)
                return null;
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear((DateTime)date);
        }
        public static int? GregorianToPersian_Month(this DateTime? date)
        {
            if (date == null)
                return null;
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetMonth((DateTime)date);
        }
        public static int? GregorianToPersian_DayOfMonth(this DateTime? date)
        {
            if (date == null)
                return null;
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetDayOfMonth((DateTime)date);
        }

        public static DateTime PersianToGregorian(this string date)
        {
            var ad = date.Split('/');
            var year = int.Parse(ad[0]);
            var month = int.Parse(ad[1]);
            var day = int.Parse(ad[2]);
            if (year < 0 && year > 2000)
                throw new ArgumentOutOfRangeException("سال مقدار قابل قبول نارد");
            if (month < 1 && month > 12)
                throw new ArgumentOutOfRangeException("ماه مقدار قابل قبول نارد");
            if (day < 1 && day > 31)
                throw new ArgumentOutOfRangeException("روز مقدار قابل قبول نارد");


            PersianCalendar pc = new PersianCalendar();
            DateTime dt2 = new DateTime(year, month, day, pc);


            DateTime dt = DateTime.Parse(date, new CultureInfo("fa-IR"));
            var dt_utc = dt.ToUniversalTime();
            var tt = Convert.ToDateTime(date, new CultureInfo("fa-IR"));
            return dt2;
        }
        public static DateTime PersianToGregorian(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, pc);
        }
    }
}
