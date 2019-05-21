// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="QuiddityAction.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base;
using OptLib.Data.BaseModels;
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;

namespace OptLib.Data.Models
{
    /// <summary>
    /// مراجع و استانارد های کدینگ
    /// </summary>
    public partial class CodingRefrance
        : EntityBaseIdNameDescription<ushort>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityBaseIdNameDescription<ushort>.Configuration<TEntityType>
            where TEntityType : CodingRefrance
        {
            public Configuration()
            {
                //Property(c => c.Id)
                //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                //    .HasColumnOrder(5)
                //    ;
                //Property(c => c.Name)
                //    .HasColumnOrder(6)
                //    ;
                //Property(c => c.Name)
                //    .HasMaxLength(25)
                //    ;
            }
        }
        #endregion 
        #region Properties
        #endregion
        #region Properties abstract
        //[NotMapped]
        //public override List<SqlBulkCopyColumnMapping> ColumnMapping
        //{
        //    get
        //    {
        //        return new List<SqlBulkCopyColumnMapping>()
        //        {
        //            new SqlBulkCopyColumnMapping("Id", "Id"),
        //        };
        //    }
        //}
        #endregion
        #region Constructors
        public CodingRefrance()
            : base()
        {

        }
        public CodingRefrance(string name)
            : base(name)
        {

        }
        public CodingRefrance(ushort id, string name)
            : base(id, name)
        {

        }
        #endregion
        #region ICollection ForeignKey
        public virtual ICollection<Coding> Codings { get; set; } = new HashSet<Coding>();
        #endregion
        #region Static Methods
        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Configuration<CodingRefrance>());

        }
        public static List<CodingRefrance> Seed<TContext>(TContext context)
            where TContext : DbContext
        {
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Coding', RESEED , 0);");
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Coding_Name ON Coding (Name)");

            var list = new List<CodingRefrance>()
            {
                new CodingRefrance("فاقد استاندارد"){ Description = "فاقد استاندارد و مرجع" },
                new CodingRefrance("عمومی"){ Description = "روشهای عمومی و معمول و بدیحی در کدینگ" },
                new CodingRefrance("GS1") { Description = "انجمن بین‌المللی غیرانتفاعی GS1 که به توسعه و حفاظت از استانداردهای جهانی مرتبط با ارتباطات تجاری می‌پردازد" },
            };
            context.Set<CodingRefrance>().AddRange(list);
            context.SaveChanges();

            return list;
        }
        #endregion
        #region Methods
        #endregion

    }
}
namespace OptLib.Data.Models.ExtensionMethods
{
    public static partial class ModelsExtensions
    {
        public static CodingRefrance GetItem(this List<CodingRefrance> list, string name)
        {
            return list.Find(x => x.Name == name);
        }
    }
}
