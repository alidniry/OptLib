﻿// ***********************************************************************
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
    public abstract partial class BaseQuiddityRelation<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        : EntityId<ulong>,
        IEntity, IId<ulong>, IEntityId<ulong>
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
            : EntityId<ulong>.Configuration<TModelQuiddityRelation>
        {
            public Configuration()
            {
                Property(c => c.Id)
                    .IsRequired()
                    .HasColumnOrder(1)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;

                HasRequired(c => c.Quiddity)
                   .WithOptional(c => c.QuiddityRelation)
                   .WillCascadeOnDelete(true)
                   ;
            }
        }
        #endregion /Configuration
        #region Properties
        public virtual TModelQuiddity Quiddity { get; set; }
        #endregion
        #region Constructors
        public BaseQuiddityRelation()
            : base()
        {

        }
        public BaseQuiddityRelation(ulong id)
            : base(id)
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
        //public static BaseQuiddityRelation GetItem(this List<BaseQuiddityRelation> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
