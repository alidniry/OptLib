// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="BaseQuiddityObject.cs" company="">
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
using OptLib.Data.BaseModality.Qdt;
using OptLib.Data.BaseModality.Qdt.Quiddity;

namespace OptLib.Data.BaseModels.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت اشیاء
    /// </summary>
    /// <seealso cref="OptLib.Data.Base.EntityBaseIdName{System.Int64}" />
    public abstract partial class BaseQdtObject<TModalityQdtQuiddity, TModalityQdtObject>
        : ModalityObject<long, TModalityQdtObject>
        where TModalityQdtQuiddity : ModalityQuiddity<long, TModalityQdtQuiddity>
        where TModalityQdtObject : ModalityObject<long, TModalityQdtObject>
    {
        #region Configuration
        public class Configuration
            : ModalityObject<long, TModalityQdtObject>.Configuration
        {
            public Configuration()
            {
                Property(c => c.Id)
                    .IsRequired()
                    .HasColumnOrder(1)
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
        #endregion /Configuration
        #region Properties
        public virtual TModalityQdtQuiddity Quiddity { get; set; }

        #endregion
        #region Constructors
        public BaseQdtObject()
            : base()
        {

        }
        public BaseQdtObject(string name)
            : base(name)
        {

        }
        public BaseQdtObject(long id/*, long cpKey*/, string name)
            : base(id/*, cpKey*/, name)
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
        //public static BaseQuiddityObject GetItem(this List<BaseQuiddityObject> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
