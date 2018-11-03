using System;
using System.Globalization;
using AutoMapper;
using System.Reflection;

//namespace OptLib.AutoMapper
namespace AttributesForAutomapper.Convertors
{

    //public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    //{
    //    public DateTime Convert(string source, DateTime destination, ResolutionContext context)
    //    {
    //        return System.Convert.ToDateTime(source);
    //    }
    //}

    //public class TypeTypeConverter : ITypeConverter<string, Type>
    //{
    //    public Type Convert(string source, Type destination, ResolutionContext context)
    //    {
    //        return Assembly.GetExecutingAssembly().GetType(source);
    //    }
    //}
    /*
    مبدل تاریخ 
    برگرفته از لینک زیر
    http://www.dotnettips.info/courses/topic/16/ddfa690e-cb70-41cb-b0b9-cb23b9ef647a
    //*/

    public class DateTimeToPersianDateTimeConverter : ITypeConverter<DateTime, string>
    {
        private readonly string _separator;
        private readonly bool _includeHourMinute;
        public DateTimeToPersianDateTimeConverter()
        {
            _separator = "/";
            _includeHourMinute = true;
        }
        public DateTimeToPersianDateTimeConverter(string separator = "/", bool includeHourMinute = true)
        {
            _separator = separator;
            _includeHourMinute = includeHourMinute;
        }

        //public string Convert(ResolutionContext context)
        //{
        //    var objDateTime = context.SourceValue;
        //    return (objDateTime == null ? string.Empty : ToShamsiDateTime((DateTime) context.SourceValue));
        //}

        public string ToShamsiDateTime(DateTime info)
        {
            return ToShamsiDateTime(info, _separator, _includeHourMinute);
        }
        //static public string ToShamsiDateTime(DateTime info, string separator = "/", bool includeHourMinute = true)
        static public string ToShamsiDateTime(DateTime info, string separator, bool includeHourMinute)
        {
            var year = info.Year;
            var month = info.Month;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pYear = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            var pMonth = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));
            var pDay = persianCalendar.GetDayOfMonth(new DateTime(year, month, day, new GregorianCalendar()));
            return includeHourMinute ?
                string.Format("{0}{1}{2}{1}{3} {4}:{5}", pYear, separator,
                pMonth.ToString("00", CultureInfo.InvariantCulture),
                pDay.ToString("00", CultureInfo.InvariantCulture),
                info.Hour.ToString("00"), info.Minute.ToString("00"))
                : string.Format("{0}{1}{2}{1}{3}", pYear, separator,
                pMonth.ToString("00", CultureInfo.InvariantCulture),
                pDay.ToString("00", CultureInfo.InvariantCulture));
        }

        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return ToShamsiDateTime(source);
        }
    }
}