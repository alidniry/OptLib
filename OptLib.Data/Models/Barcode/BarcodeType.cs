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
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;

namespace OptLib.Data.Models
{
    /// <summary>
    /// جدول سرفصل اول کدینگها
    /// </summary>
    public partial class BarcodeType
        : EntityBaseIdName<ushort>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityBaseIdName<ushort>.Configuration<TEntityType>
            where TEntityType : BarcodeType
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
                Property(c => c.Name)
                    .HasMaxLength(36)
                    ;
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
        public BarcodeType()
            : base()
        {

        }
        public BarcodeType(string name)
            : base(name)
        {

        }
        public BarcodeType(ushort id, string name)
            : base(id, name)
        {

        }
        #endregion
        #region ICollection ForeignKey
        public virtual ICollection<Barcode> Barcodes { get; set; } = new HashSet<Barcode>();
        #endregion
        #region Static Methods
        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Configuration<BarcodeType>());

        }
        public static void Seed<TContext>(TContext context)
            where TContext : DbContext
        {
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('BarcodeType', RESEED , 0);");
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_BarcodeType_Name ON BarcodeType (Name)");

            var list = new List<BarcodeType>()
            {
                new BarcodeType("نامعلوم"),
                new BarcodeType("Codabar"),
                new BarcodeType("Code 11 (USD-8)"),
                new BarcodeType("Code 128"),
                new BarcodeType("Code 39 (USD-3)"),
                new BarcodeType("Code 39 Extended"),
                new BarcodeType("Code 93"),
                new BarcodeType("Code 93 Extended"),
                new BarcodeType("EAN 8"),
                new BarcodeType("EAN 13"),
                new BarcodeType("EAN-128 (UCC)"),
                new BarcodeType("Industrial 2 of 5"),
                new BarcodeType("Interleaved 2 of 5"),
                new BarcodeType("Matrix 2 of 5"),
                new BarcodeType("MSI - Plessey"),
                new BarcodeType("PostNet"),
                new BarcodeType("UPC Supplemental 2"),
                new BarcodeType("UPC Supplemental 5"),
                new BarcodeType("UPC-A"),
                new BarcodeType("UPC-E0"),
                new BarcodeType("UPC-E1"),
                new BarcodeType("GS1 DataBar"),
                new BarcodeType("UPC Shipping Container Symbol (ITF-14)"),
                //Expanded 2D Bar Codes
                new BarcodeType("Data Matrix (ECC200)"),
                new BarcodeType("GS1- Data Matrix"),
                new BarcodeType("Intelligent Mail"),
                new BarcodeType("PDF417"),
                new BarcodeType("QR Code"),
            };
            context.Set<BarcodeType>().AddRange(list);
            context.SaveChanges();
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
        public static BarcodeType GetItem(this List<BarcodeType> list, string name)
        {
            return list.Find(x => x.Name == name);
        }
    }
}
