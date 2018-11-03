using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using AutoMapper;
using System.Linq.Expressions;
using System;
using System.Text.RegularExpressions;
using AutoMapper.Configuration;

namespace OptLib.AutoMapper
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// هر IMappingExpression دارای امکاناتی برای نگهداری و انجام فعالیت بر روی یک نگاشت می‌باشد. در کوئری ابتدای متد، کلیه‌ی پروپرتی‌هایی را که دارای ویژگی MapForMemeberAttribute می‌باشند، یافته و جدا می‌کنیم. این پروپرتی‌ها از نظر معادل اسمی در نوع مبدأ و مقصد متفاوت هستند. سپس در حلقه، کار اتصال پروپرتی مبدأ و مقصد صورت می‌گیرد.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression DoMapForMemberAttribute(this IMappingExpression expression)
        {
            var ok =
                from p in (expression as MappingExpression).Types.DestinationType.GetProperties()
                let attr = p.GetCustomAttribute<MapForMemberAttribute>()
                where attr != null
                select new { AttributeValue = attr, PropertyName = p.Name };

            foreach (var property in ok)
            {
                expression.ForMember(property.PropertyName,
                    opt => opt.MapFrom(property.AttributeValue.MemberToMap));
            }
            return expression;
        }

        /// <summary>
        /// این متد کلیه‌ی پروپرتی‌هایی را که دارای ویژگی IgnoreMapAttribute باشند، از گردونه‌ی نگاشت automapper خارج می‌کند. به عنوان مثال پروپرتی Password در ویوومدل مربوط به تغییر گذرواژه را نظر بگیرید. این پروپرتی نباید مقدار معادلی در شیء EF داشته باشد. از طرفی هم باید در ویوو وجودداشته باشد. با استفاده از این ویژگی هیچ نگاشتی انجام نمی‌شود و می‌توان تضمین کرد که گذرواژه به ویوومدل و ویوو راه پیدا نمی‌کند.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression DoIgnoreMapAttribute(this IMappingExpression expression)
        {
            var ok =
                (expression as MappingExpression).Types.DestinationType.GetProperties()
                .Where(x => x.GetCustomAttribute<IgnoreMapAttribute>() != null);

            foreach (var property in ok)
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }



        /// <summary>
        /// این متد برحسب پرچم تعیین شده در هنگام بکارگیری ویژگی MapFromAttribute رفتار می‌کند. به این صورت که اگر موقع تعریف، مقدار IgnoreAllNonExistingProperty را صحیح اعلام کنیم، تمام پروپرتی‌های مقصد را که معادل اسمی در مبدأ نداشته باشند و همچنین هیچگونه تنظیمی جهت مشخص سازی تکلیف نگاشت آن‌ها صورت نگرفته باشد، از گردونه‌ی نگاشت Automapper خارج می‌کند.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression DoIgnoreAllNonExisting(this IMappingExpression expression)
        {
            var attr = (expression as MappingExpression).Types.DestinationType.GetCustomAttribute<MapFromAttribute>();

            if (attr?.IgnoreAllNonExistingProperty == false)//instead of if(attr == null || attr.IgnoreAllNonExistingProperty == false)
                return expression;

            //expression.ForAllOtherMembers(x => x.Ignore());
            var flags = BindingFlags.Public | BindingFlags.Instance;

            var sourceType = (expression as MappingExpression).SourceType; //typeof(TSource);
            var destinationType = (expression as MappingExpression).DestinationType; // typeof(TDestination);
            var destinationProperties = destinationType.GetProperties(flags)
                .Where(x => x.GetCustomAttribute<IgnoreMapAttribute>() == null &&
                       x.GetCustomAttribute<UseValueResolverAttribute>() == null &&
                       x.GetCustomAttribute<MapForMemberAttribute>() == null);

            //MapperConfiguration MapperConfiguration = new MapperConfiguration(cfg =>
            //{
            //    typeof(Person).GetTypeInfo().Assembly.MapTypes(cfg);
            //});
            //IMapper mapper = MapperConfiguration.CreateMapper();

            //var existingMaps = MapperConfiguration.FindTypeMapFor(sourceType, destinationType);
            //.First(x => x.SourceType.Equals(sourceType) && x.DestinationType.Equals(destinationType));
            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) != null)
                {
                    expression.ForMember(property.Name, opt => opt.MapFrom(property.Name));
                    //if()
                }
                else
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            //foreach (var property in existingMaps.GetUnmappedPropertyNames())
            //{
            //    expression.ForMember(property, opt => opt.Ignore());
            //}
            return expression;
        }

        /// <summary>
        /// به شیوه‌ی قبل، ابتدا نوع هایی را که دارای ویژگی UseValueResolverAttribute باشند، یافته و جدا می‌کنیم. سپس در حلقه، کار نگاشت متناظر در automapper انجام می‌گیرد. لازم به ذکر است که متد opt.ResolveUsing یک شیء با کارآیی (can do) اینترفیس IValueResolver را به عنوان آرگومان می‌گیرد.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression DoUseValueResolverAttribute(this IMappingExpression expression)
        {
            var ok =
                from p in (expression as MappingExpression).Types.DestinationType.GetProperties()
                let attr = p.GetCustomAttribute<UseValueResolverAttribute>()
                where attr != null
                select new { AttributeValue = attr, PropertyName = p.Name };

            foreach (var property in ok)
            {
                expression.ForMember(property.PropertyName,
                    opt => opt.ResolveUsing(property.AttributeValue.ValueResolver));
            }
            return expression;
        }

        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            var existingMaps = Mapper.Configuration.GetAllTypeMaps().First(x => x.SourceType.Equals(sourceType)
                && x.DestinationType.Equals(destinationType));
            foreach (var property in existingMaps.GetUnmappedPropertyNames())
            {
                expression.ForMember(property, opt => opt.Ignore());
            }
            return expression;
        }
        public static IMappingExpression<TSource, TDestination> Map<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map,
            Expression<Func<TSource, object>> src,
            Expression<Func<TDestination, object>> dst)
        {
            map.ForMember(dst, opt => opt.MapFrom(src));
            return map;
        }
    }
}
