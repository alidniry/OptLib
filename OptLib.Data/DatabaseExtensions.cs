using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.Data.ExtensionMethods 
{
    public static partial class DatabaseExtensions
    {
        public static PrimitivePropertyConfiguration HasIndexAnnotation(
           this PrimitivePropertyConfiguration primitivePropertyConfiguration,
           IndexAttribute indexAttribute = null
           )
        {
            indexAttribute = indexAttribute ?? new IndexAttribute();

            return primitivePropertyConfiguration
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(indexAttribute)
                );
        }

        public static long Count<TEntity>(this DbContext context, string wherestring = null) /*, wherestring = " WHERE ENTITY_ID IS NOT NULL "*/
        {
            string tableName = context.GetEntityName<TEntity>();
            string sql = $"SELECT Count(*) FROM {tableName} { (wherestring != null ? wherestring : "")};";

            return context.Database.SqlQuery<int>(sql).FirstOrDefault<int>();
        }

        public static TEntity GetItem<TEntity>(this DbContext context, string where)
        {
            string tableName = context.GetEntityName<TEntity>();
            string sql = $"SELECT * FROM { tableName } " +
                $" WHERE { where };";
            return context.Database.SqlQuery<TEntity>(sql).SingleOrDefault();
        }
        public static List<TEntity> GetItems<TEntity>(this DbContext context, string orderbyname, int? take = null, int skip = 0)
        {
            string tableName = context.GetEntityName<TEntity>();
            string sql = $"SELECT * FROM {tableName} " +
                $"ORDER BY {orderbyname} OFFSET {skip} ROWS " +
                $"{(take != null ? $"FETCH NEXT {take} ROWS ONLY;" : ";")}";
            return context.Database.SqlQuery<TEntity>(sql).ToList();
        }
        public static List<TEntity> GetItems<TEntity>(this DbContext context)
        {
            string tableName = context.GetEntityName<TEntity>();
            string sql = $"SELECT * FROM {tableName} ;";
            return context.Database.SqlQuery<TEntity>(sql).ToList();
        }
        public static List<TEntity> GetItems<TEntity>(this DbContext context, string SelectFileds)
        {
            string tableName = context.GetEntityName<TEntity>();
            string sql = $"SELECT { SelectFileds } FROM {tableName} ;";
            return context.Database.SqlQuery<TEntity>(sql).ToList();
        }

        public static string GetEntityName<TEntity>(this DbContext entity)
        {
            return (typeof(TEntity).GetAttributeValue((TableAttribute dna) => dna.Name) != null ? typeof(TEntity).GetAttributeValue((TableAttribute dna) => dna.Name) : typeof(TEntity).Name);
        }
    }
    public static partial class AttributeExtensions
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(
            this Type type,
            Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(
                typeof(TAttribute), true
            ).FirstOrDefault() as TAttribute;
            if (att != null)
            {
                return valueSelector(att);
            }
            return default(TValue);
        }
    }
}
