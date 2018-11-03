using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.AutoMapper
{
    /// <summary>
    /// برای ادغام کلاس و تنظیمات نگاشت در اینجا راهکاری ارائه گردید که در ادامه و با الگو گیری از همین ایده، اقدام به ارائه‌ی روشی جدید می‌کنم که با استفاده از اتریپها تنظیمات نگاشت اشیاء را در اتو مپر انجام می‌دهد.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MapFromAttribute : Attribute
    {
        public Type SourceType { get; private set; }
        public bool IgnoreAllNonExistingProperty { get; private set; }
        public bool AlsoCopyMetadata { get; private set; }    //Go to: http://www.dotnettips.info/courses/topic/16/cb36bc2e-4263-431e-86a5-236322cb5576

        /// <summary>
        /// Initializes a new instance of the <see cref="MapFromAttribute"/> class.
        /// </summary>
        /// <param name="sourceType">، نوع مبدأ را برای اتو مپر مشخص می‌کند. </param>
        /// <param name="ignoreAllNonExistingProperty">کلیه‌ی صفاتی که در مقصد هستند ولی معادل اسمی در مبدأ ندارند، بصورت خودکار رد شده و از آن‌ها صرف نظر شود تا از شکست متد  جلوگیری کند</param>
        /// <param name="alsoCopyMetadata">می‌تواند پرچمی باشد تا اجازه دهد  دیتابیسی از مدل‌های انتیتی به وییو انتقال یابند.</param>
        public MapFromAttribute(
            Type sourceType,
            bool ignoreAllNonExistingProperty = false, //  AutoMapper.Mapper.AssertConfigurationIsValid
            bool alsoCopyMetadata = false)
        {
            SourceType = sourceType;
            IgnoreAllNonExistingProperty = ignoreAllNonExistingProperty;
            AlsoCopyMetadata = alsoCopyMetadata;
        }
    };

    /// <summary>
    /// از این صفت برای رد کردن خصیصه‌‌ای در نگاشت‌ها استفاده می‌کنیم. لازم به ذکر است که صفتی مشابه در اتو مپر وجود دارد که می‌تواند به جای این صفت مورد استفاده قرار گیرد. «نگارنده جهت همخوانی با سایر صفات، اقدام به استفاده‌ی از این صفت می‌کند»
    /// Automapper.IgnoreAttribute
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreMapAttribute : Attribute { };

    /// <summary>
    /// اگر نام خصیصه‌ها در مبدأ و مقصد یکی نباشند، از این صفت برای همگام سازی این دو استفاده می‌کنیم.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public class MapForMemberAttribute : Attribute
    {
        public string MemberToMap { get; private set; }
        public MapForMemberAttribute(string memberToMap)
        {
            MemberToMap = memberToMap;
        }
    };

    /// <summary>
    /// از این صفت برای تنظیم این مقدار برای یک خصیصه استفاده می‌شود. 
    /// برای مثال فیلد FullName را در مقصد درنظر بگیرد که از دو فیلد Name و Family در مبدأ تشکیل می‌شود..
    /// </summary>
    /// <seealso cref="System.Attribute" />
    //[AttributeUsage(AttributeTargets.Property)]
    //public class UseValueResolverAttribute : Attribute
    //{
    //    public IValueResolver ValueResolver { get; private set; }
    //    public UseValueResolverAttribute(Type valueResolver)
    //    {
    //        ValueResolver = valueResolver.GetConstructors()[0].Invoke(new object[] { }) as IValueResolver<object, object, object>;
    //        //ValueResolver = valueResolver.GetConstructors()[0].Invoke(new object[] { }) as IValueResolver;
    //    }
    //};
    [AttributeUsage(AttributeTargets.Property)]
    public class UseValueResolverAttribute : Attribute
    {
        public IValueResolver<object, object, object> ValueResolver { get; private set; }
        public UseValueResolverAttribute(Type valueResolver)
        {
            ValueResolver = valueResolver.GetConstructors()[0].Invoke(new object[] { }) as IValueResolver<object, object, object>;
        }
    };
}
