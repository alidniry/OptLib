// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="BaseQuiddityPosition.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using OptLib.Data.Base.Interface;

namespace OptLib.Data.BaseModality.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت موقعیت
    /// </summary>
    public abstract partial class ModalityPosition<TKey, TModalityQdtPosition>
        : EntityIdCPKey<TKey>,
        IEntity, IId<TKey>, IEntityId<TKey>, IEntityIdCPKey<TKey>
        where TModalityQdtPosition : ModalityPosition<TKey, TModalityQdtPosition>
    {
        #region Configuration
        public class Configuration
            : Configuration<TModalityQdtPosition>
        {
            public Configuration()
            {
                HasKey(c => new { c.Id, c.CPKey })
                    ;
                Property(c => c.CPKey)
                    .HasColumnOrder(2)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
            }
        }
        #endregion
        #region Properties
        ///// <summary>
        ///// GS1 Company Prefix Key
        ///// </summary>
        //public long CPKey { get; set; } = 0; //0 : فاقد سیستم کدینگ 
        #endregion
        #region Constructors
        public ModalityPosition()
            : base()
        {

        }
        public ModalityPosition(TKey id, long cpKey)
            : base(id, cpKey)
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
        //public static BaseQuiddityPosition GetItem(this List<BaseQuiddityPosition> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
