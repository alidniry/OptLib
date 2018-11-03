// ***********************************************************************
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
using QptLib.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;

namespace OptLib.Data.BaseModels
{
    /// <summary>
    /// ماهیت تخصیص منابع
    /// </summary>
    public abstract partial class BaseQuiddityAllocationResource<TEntity>
        : EntityIdName<TEntity>, IHistory
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityIdName<TEntity>.Configuration<TEntityType>
            where TEntityType : BaseQuiddityAllocationResource<TEntity>
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
                //Property(current => current.Name)
                //    .HasMaxLength(25)
                //    ;
            }

        }
        #endregion /Configuration

        public BaseQuiddityAllocationResource()
        {

        }

        public _History History { get; set; } = new _History();
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
