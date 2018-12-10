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
using OptLib.Data.BaseModality.Qdt;
using OptLib.Data.BaseModality.Qdt.Quiddity;

namespace OptLib.Data.BaseModels.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت موقعیت
    /// </summary>
    public abstract partial class BaseQdtPosition<TModalityQdtQuiddity, TModalityQdtPosition>
        : ModalityPosition<long, TModalityQdtPosition>,
        IEntity, IId<long>, IEntityId<long>
        where TModalityQdtQuiddity : ModalityQuiddity<long, TModalityQdtQuiddity>
        where TModalityQdtPosition : ModalityPosition<long, TModalityQdtPosition>
    {
        #region Configuration
        public class Configuration
            : ModalityPosition<long, TModalityQdtPosition>.Configuration
        {
            public Configuration()
            {
                Property(c => c.Id)
                    .IsRequired()
                    .HasColumnOrder(1)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
            }
        }
        #endregion /Configuration
        #region Properties
        public virtual TModalityQdtQuiddity Quiddity { get; set; }
        #endregion
        #region Constructors
        public BaseQdtPosition()
            : base()
        {

        }
        public BaseQdtPosition(long id, long cpKey)
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
