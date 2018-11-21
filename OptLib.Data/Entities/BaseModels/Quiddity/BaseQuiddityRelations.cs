// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="BaseQuiddityRelation.cs" company="">
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

namespace OptLib.Data.BaseModels
{
    /// <summary>
    /// ماهیت ارتباطات داده ای
    /// </summary>
    public abstract partial class BaseQuiddityRelation
        : BaseQuiddity,
        IEntity, IId<long>, IEntityId<long>, IHistory
    {
        #region Configuration
        public class Configuration<TEntityType>
            : BaseQuiddity.Configuration<TEntityType>
            where TEntityType : BaseQuiddityRelation
        {
            public Configuration()
            {

            }

        }
        #endregion /Configuration
        #region Properties
        #endregion
        #region Constructors
        public BaseQuiddityRelation()
            : base()
        {

        }
        public BaseQuiddityRelation(_History history)
            : base()
        {
            this.SetValue(history);
        }
        public BaseQuiddityRelation(long id, _History history)
            : base(id)
        {
            this.SetValue(history);
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
        //public static BaseQuiddityRelation GetItem(this List<BaseQuiddityRelation> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
