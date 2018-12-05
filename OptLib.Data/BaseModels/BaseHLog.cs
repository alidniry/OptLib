// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-14-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-14-2018
// ***********************************************************************
// <copyright file="bQdtActions.cs" company="">
//     Copyright © Taradis 2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.Spatial;
using System.Linq.Expressions;
using OptLib.Data.BaseModels;
using OptLib.Data.Models;
using OptLib.Data.Base;
using OptLib.Data.Interface;
using OptLib.Data.ComplexType;

namespace OptLib.Data.bModels
{
    /// <summary>
    /// ماهیت فعالیتها
    /// </summary>
    /// <seealso cref="OptLib.Data.Models.BaseQuiddityAction" />
    public abstract partial class BaseHLog<TEntity>
        : EntityBaseIdName<TEntity>
    {
        #region Configuration
        public class Configuration<TEntityType>
        : EntityBaseIdName<TEntity>.Configuration<TEntityType>
        where TEntityType : BaseHLog<TEntity>
        {
            public Configuration()
            {

            }

        }
        #endregion /Configuration

        public BaseHLog()
            : base()
        {

        }
        public BaseHLog(string name)
            : base(name)
        {

        }

        //[Required]
        public _HistoryLog HistoryLog { get; set; } = new _HistoryLog();

    }
}
namespace OptLib.Data.Models.ExtensionMethods
{
    /// <summary>
    /// Class ModelsExtensions.
    /// </summary>
    public static partial class ModelsExtensions
    {
        //public static QdtAction GetItem(this List<QdtAction> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
