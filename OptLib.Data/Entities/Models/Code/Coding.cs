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
using OptLib.Data.Models.ExtensionMethods;

namespace OptLib.Data.Models
{
    /// <summary>
    /// روشهای کدینگ
    /// </summary>
    public partial class Coding
        : EntityIdNameDescription<uint>
    {
        #region Configuration
        public class Configuration/*<TEntityType>*/
            : EntityIdName<uint>.Configuration<Coding>
            //where TEntityType : Coding
        {
            public Configuration()
            {
                Property(c => c.RefranceId)
                    .IsRequired()
                    ;
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

                //one - to - many
                HasOptional(c => c.Refrance)
                    .WithMany(c => c.Codings)
                    .HasForeignKey(c => c.RefranceId)
                    .WillCascadeOnDelete(false)
                    ;
            }
        }
        #endregion 
        #region Properties 
        public virtual ushort RefranceId { get; set; } = 0;
        public virtual CodingRefrance Refrance { get; set; }

        public bool QuiddityActions { get; set; } = false;
        public bool QuiddityActors { get; set; } = false;
        public bool QuiddityAllocationResources { get; set; } = false;
        public bool QuiddityConnections { get; set; } = false;
        public bool QuiddityObjects { get; set; } = false;
        public bool QuiddityPositions { get; set; } = false;
        public bool QuiddityPrices { get; set; } = false;
        public bool QuiddityRelations { get; set; } = false;
        public bool QuiddityServices { get; set; } = false;
        #endregion
        #region Constructors
        public Coding()
            : base()
        {

        }
        public Coding(string name, ushort refranceId)
            : base(name)
        {
            this.SetValue(refranceId);
        }
        public Coding(uint id, string name, ushort refranceId)
            : base(id, name)
        {
            this.SetValue(refranceId);
        }
        #endregion
        #region ICollection ForeignKey
        #endregion
        #region Static Methods
        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Configuration<Coding>());

        }
        public static void Seed<TContext>(TContext context)
            where TContext : DbContext
        {
            //databaseContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Coding', RESEED , 0);");
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Coding_Name ON Coding (Name)");
            var lcr = CodingRefrance.Seed(context);

            var list = new List<Coding>()
            {
                new Coding("GTIN", lcr.GetItem("GS1").Id){ Description="برای قلم تجاری" },
                new Coding("SSCC", lcr.GetItem("GS1").Id){ Description="به‌منظور واحدهای لجستیکی" },
                new Coding("GIAI", lcr.GetItem("GS1").Id){ Description="برای دارایی‌های ثابت" },
                new Coding("GRAI", lcr.GetItem("GS1").Id){ Description="برای دارایی‌های برگشتنی" },
                new Coding("GLN", lcr.GetItem("GS1").Id){ Description="جهت شناسایی هویت‌های حقیقی و حقوقی و مکان‌های فیزیکی و دیجیتالی" },
                new Coding("GDTI", lcr.GetItem("GS1").Id){ Description="برای اسناد" },
                new Coding("GSIN", lcr.GetItem("GS1").Id){ Description="" },
                new Coding("GINC", lcr.GetItem("GS1").Id){ Description="" },
                new Coding("GSRN", lcr.GetItem("GS1").Id){ Description="" },
            };
            context.Set<Coding>().AddRange(list);
            context.SaveChanges();
        }
        #endregion
        #region Methods
        public void SetValue(ushort refranceId)
        {
            this.RefranceId = refranceId;
        }
        #endregion
    }
}
namespace OptLib.Data.Models.ExtensionMethods
{
    public static partial class ModelsExtensions
    {
        public static Coding GetItem(this List<Coding> list, string name)
        {
            return list.Find(x => x.Name == name);
        }
    }
}
