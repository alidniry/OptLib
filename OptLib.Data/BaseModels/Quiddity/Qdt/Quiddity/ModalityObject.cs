﻿// ***********************************************************************
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

namespace OptLib.Data.BaseModality.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت اشیاء
    /// </summary>
    public abstract partial class ModalityObject<TKey, TModalityQdtObject>
        : EntityIdName<TKey>
        where TModalityQdtObject : ModalityObject<TKey, TModalityQdtObject>
    {
        #region Configuration
        public class Configuration
            : Configuration<TModalityQdtObject>
        {
            public Configuration()
            {
                //HasKey(c => new { c.Id, c.CPKey })
                //    ;
                //Property(c => c.CPKey)
                //    .HasColumnOrder(2)
                //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                //    ;
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
        public ModalityObject()
            : base()
        {

        }
        public ModalityObject(string name)
            : base(name)
        {

        }
        public ModalityObject(TKey id/*, long cpKey*/, string name)
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
