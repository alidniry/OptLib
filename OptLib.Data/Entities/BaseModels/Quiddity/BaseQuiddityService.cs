// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="BaseQuiddityService.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base;
using OptLib.Data.Base.Interface;
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Spatial;

namespace OptLib.Data.BaseModels
{
    /// <summary>
    /// ماهیت خدمات
    /// </summary>
    public abstract partial class BaseQuiddityService<TModelQuiddity, TModelQuiddityAction, TModelQuiddityActor, TModelQuiddityAllocationResource, TModelQuiddityConnection, TModelQuiddityObject, TModelQuiddityPosition, TModelQuiddityPrice, TModelQuiddityRelation, TModelQuiddityService>
        : EntityIdName<ulong>,
        IEntity, IId<ulong>, IEntityId<ulong>, IEntityIdName<ulong>
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
            : EntityIdName<ulong>.Configuration<TModelQuiddityService>
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
                    .HasColumnOrder(2)
                    .HasMaxLength(128)
                    ;

                HasRequired(c => c.Quiddity)
                   .WithOptional(c => c.QuiddityService)
                   .WillCascadeOnDelete(true)
                   ;
            }
        }
        #endregion /Configuration
        #region Properties
        public virtual TModelQuiddity Quiddity { get; set; }
        #endregion
        #region Constructors
        public BaseQuiddityService()
            : base()
        {

        }
        public BaseQuiddityService(string name)
            : base(name)
        {

        }
        public BaseQuiddityService(ulong id, string name)
            : base(id, name)
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
        //public static BaseQuiddityService GetItem(this List<BaseQuiddityService> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
