﻿// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="BaseQuiddityAllocationResource.cs" company="">
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
    /// ماهیت تخصیص منابع
    /// </summary>
    public abstract partial class BaseQdtAllocationResource<TModalityQdtQuiddity, TModalityQdtAllocationResource>
        : ModalityAllocationResource<long, TModalityQdtAllocationResource>
        where TModalityQdtQuiddity : ModalityQuiddity<long, TModalityQdtQuiddity>
        where TModalityQdtAllocationResource : ModalityAllocationResource<long, TModalityQdtAllocationResource>
    {
        #region Configuration
        public class Configuration
            : ModalityAllocationResource<long, TModalityQdtAllocationResource>.Configuration
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
        public BaseQdtAllocationResource()
            : base()
        {

        }
        public BaseQdtAllocationResource(string name)
            : base(name)
        {

        }
        public BaseQdtAllocationResource(long id/*, long cpKey*/, string name)
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
        //public static BaseQuiddityAllocationResource GetItem(this List<BaseQuiddityAllocationResource> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
