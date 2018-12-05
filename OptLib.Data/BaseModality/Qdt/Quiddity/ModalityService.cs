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
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Spatial;

namespace OptLib.Data.BaseModality.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت خدمات
    /// </summary>
    public abstract partial class ModalityService<TKey, TModalityQdtService>
        : EntityIdName<TKey>,
        IEntity, IId<TKey>, IEntityId<TKey>, IEntityIdName<TKey>
        where TModalityQdtService : ModalityService<TKey, TModalityQdtService>
    {
        #region Configuration
        public class Configuration
            : Configuration<TModalityQdtService>
        {
            public Configuration()
            {
                HasKey(c => new { c.Id, c.CPKey })
                    ;
                Property(c => c.CPKey)
                    .HasColumnOrder(2)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
                Property(c => c.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar")
                    .HasColumnOrder(3)
                    .HasMaxLength(128)
                    ;
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// GS1 Company Prefix Key
        /// </summary>
        public long CPKey { get; set; } = 0; //0 : فاقد سیستم کدینگ 
        #endregion
        #region Constructors
        public ModalityService()
            : base()
        {

        }
        public ModalityService(string name)
            : base(name)
        {

        }
        public ModalityService(TKey id, string name)
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
