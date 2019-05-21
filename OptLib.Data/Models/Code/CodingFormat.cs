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
    /// روشهای فرمت کدینگها
    /// </summary>
    public partial class CodingFormat
        : EntityBaseIdNameDescription<int>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityBaseIdName<int>.Configuration<TEntityType>
            where TEntityType : CodingFormat
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
        public CodingFormat()
            : base()
        {

        }
        public CodingFormat(string name)
            : base(name)
        {

        }
        #endregion
        #region ICollection ForeignKey
        #endregion
        #region Static Methods
        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Configuration<CodingFormat>());

        }
        public static void Seed<TContext>(TContext context)
            where TContext : DbContext
        {
            //databaseContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Coding', RESEED , 0);");
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Coding_Name ON Coding (Name)");

            var list = new List<CodingFormat>()
            {
                new CodingFormat(""),
            };
            context.Set<CodingFormat>().AddRange(list);
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
        public static CodingFormat GetItem(this List<CodingFormat> list, string name)
        {
            return list.Find(x => x.Name == name);
        }
    }
}
