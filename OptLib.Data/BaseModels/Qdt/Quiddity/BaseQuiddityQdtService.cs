// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="BaseQuiddityService.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base;
using OptLib.Data.Base.Interface;
using OptLib.Data.BaseModality.Qdt;
using OptLib.Data.BaseModality.Qdt.Quiddity;
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Spatial;

namespace OptLib.Data.BaseModels.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت خدمات
    /// </summary>
    public abstract partial class BaseQdtService<TModalityQdtQuiddity, TModalityQdtService>
        : ModalityService<long, TModalityQdtService>,
        IEntity, IId<long>, IEntityId<long>, IEntityIdName<long>
        where TModalityQdtQuiddity : ModalityQuiddity<long, TModalityQdtQuiddity>
        where TModalityQdtService : ModalityService<long, TModalityQdtService>
    {
        #region Configuration
        public class Configuration
            : ModalityService<long, TModalityQdtService>.Configuration
        {
            public Configuration()
            {
                Property(c => c.Id)
                    .IsRequired()
                    .HasColumnOrder(1)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
                //HasRequired(c => c.Quiddity)
                //   .WithOptional(c => c.QdtService)
                //   .WillCascadeOnDelete(true)
                //   ;
            }
        }
        #endregion /Configuration
        #region Properties
        public virtual TModalityQdtQuiddity Quiddity { get; set; }
        #endregion
        #region Constructors
        public BaseQdtService()
            : base()
        {

        }
        public BaseQdtService(string name)
            : base(name)
        {

        }
        public BaseQdtService(long id, string name)
            : base(id, name)
        {

        }
        #endregion
        #region Static Methods
        #endregion
        #region Methods
        #endregion
    }
}
namespace OptLib.Data.Models.ExtensionMethods
{
    public static partial class ModelsExtensions
    {
        //public static BaseQuiddityService GetItem(this List<BaseQuiddityService> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
