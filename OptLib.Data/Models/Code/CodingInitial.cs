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

namespace OptLib.Data.Models
{
    /// <summary>
    /// جدول سرفصل اول کدینگها
    /// </summary>
    public partial class CodingInitial
        : EntityBaseIdNameDescription<long>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityBaseIdName<long>.Configuration<TEntityType>
            where TEntityType : CodingInitial
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
                    .HasMaxLength(128)
                    ;
            }
        }
        #endregion
        #region Properties 
        #endregion
        #region Constructors
        public CodingInitial()
            : base()
        {

        }
        public CodingInitial(string name)
            : base(name)
        {

        }
        #endregion
        #region ICollection ForeignKey
        #endregion
        #region Static Methods
        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Configuration<CodingInitial>());

        }
        public static void Seed<TContext>(TContext context)
            where TContext : DbContext
        {
            //databaseContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Coding', RESEED , 0);");
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Coding_Name ON Coding (Name)");

            var list = new List<CodingInitial>()
            {
                new CodingInitial(""),
            };
            context.Set<CodingInitial>().AddRange(list);
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
        public static CodingInitial GetItem(this List<CodingInitial> list, string name)
        {
            return list.Find(x => x.Name == name);
        }
    }
}
