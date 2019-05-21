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
using Optlib.Data.BulkCopy.Mapping;
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
    public partial class Barcode
        : EntityBaseIdNameDescription<ulong>
    {
        #region Configuration
        public class Configuration/*<TEntityType>*/
            : EntityBaseIdNameDescription<ulong>.Configuration<Barcode>
        //where TEntityType : Barcode
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
                //    .HasMaxLength(64)
                //    ;

                //one - to - many
                HasOptional(c => c.Type)
                    .WithMany(c => c. Barcodes)
                    .HasForeignKey(c => c.TypeId)
                    .WillCascadeOnDelete(false)
                    ;
            }
        }
        #endregion
        #region Properties 
        [ModelMap]
        public virtual ushort TypeId { get; set; }
        public virtual BarcodeType Type { get; set; }
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
        public Barcode()
            : base()
        {

        }
        public Barcode(string name, ushort typeId)
            : base(name)
        {
            this.SetValue(typeId);
        }
        public Barcode(ulong id, string name, ushort typeId)
            : base(id, name)
        {
            this.SetValue(typeId);
        }
        #endregion
        #region ICollection ForeignKey
        #endregion
        #region Static Methods
        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Configuration<Barcode>());

        }
        public static void Seed<TContext>(TContext context)
            where TContext : DbContext
        {
            //context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Barcode', RESEED , 0);");
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Barcode_Name ON Barcode (Name)");
        }
        #endregion
        #region Methods
        public void SetValue(ushort typeId)
        {
            this.TypeId = typeId;
        }
        #endregion
    }
}
namespace OptLib.Data.Models.ExtensionMethods
{
    public static partial class ModelsExtensions
    {
        public static Barcode GetItem(this List<Barcode> list, string name)
        {
            return list.Find(x => x.Name == name);
        }
    }
}
