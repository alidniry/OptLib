﻿// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="QuiddityAction.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base;
using OptLib.Data.Base.Interface;
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.BaseModels
{
    /// <summary>
    /// ماهیت ها
    /// </summary>
    public abstract partial class BaseQuiddity<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        : EntityId<long>,
        IEntity, IId<long>, IEntityId<long>, IHistory
        where TModelQuiddity : BaseQuiddity<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        where TModelQuiddityAction : BaseQuiddityAction<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        where TModelQuiddityActor : BaseQuiddityActor<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        where TModelQuiddityAllocationResource : BaseQuiddityAllocationResource<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        where TModelQuiddityConnection : BaseQuiddityConnection<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        where TModelQuiddityObject : BaseQuiddityObject<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        where TModelQuiddityPosition : BaseQuiddityPosition<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        where TModelQuiddityPrice : BaseQuiddityPrice<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        where TModelQuiddityRelation : BaseQuiddityRelation<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        where TModelQuiddityService : BaseQuiddityService<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
    {
        #region Configuration
        public class Configuration
            : EntityId<long>.Configuration<TModelQuiddity>
        {
            public Configuration()
            {

            }

        }
        #endregion /Configuration
        #region Properties
        public virtual _History History { get; set; } = new _History();
        public virtual TModelQuiddityAction QuiddityAction { get; set; }
        public virtual TModelQuiddityActor QuiddityActor { get; set; }
        public virtual TModelQuiddityAllocationResource QuiddityAllocationResource { get; set; }
        public virtual TModelQuiddityConnection QuiddityConnection { get; set; }
        public virtual TModelQuiddityObject QuiddityObject { get; set; }
        public virtual TModelQuiddityPosition QuiddityPosition { get; set; }
        public virtual TModelQuiddityPrice QuiddityPrice { get; set; }
        public virtual TModelQuiddityRelation QuiddityRelation { get; set; }
        public virtual TModelQuiddityService QuiddityService { get; set; }
        #endregion
        #region Constructors
        public BaseQuiddity()
            : base()
        {

        }
        public BaseQuiddity(long id)
            : base(id)
        {

        }
        public BaseQuiddity(_History history)
            : base()
        {
            this.SetValue(history);
        }
        public BaseQuiddity(long id, _History history)
            : base(id)
        {
            this.SetValue(history);
        }
        #endregion
        #region Static Methods
        #endregion
        #region Methods
        public void SetValue(_History history)
        {
            this.History = history;
        }
        #endregion
    }
}
namespace OptLib.Data.Models.ExtensionMethods
{
    public static partial class ModelsExtensions
    {
        //public static BaseQuiddity GetItem(this List<BaseQuiddity> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
