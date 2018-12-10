// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="QuiddityActor.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base;
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
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
    /// ماهیت عاملین
    /// </summary>
    public abstract partial class BaseQdtActor<TModalityQdtQuiddity, TModalityQdtActor>
        : ModalityActor<long, TModalityQdtActor>,
        IEntity, IId<long>, IEntityId<long>
        where TModalityQdtQuiddity : ModalityQuiddity<long, TModalityQdtQuiddity>
        where TModalityQdtActor : ModalityActor<long, TModalityQdtActor>
    {
        #region Configuration
        public class Configuration
            : ModalityActor<long, TModalityQdtActor>.Configuration
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
        #endregion
        #region Properties
        public virtual TModalityQdtQuiddity Quiddity { get; set; }
        #endregion
        #region Constructors
        public BaseQdtActor()
            : base()
        {

        }
        public BaseQdtActor(long id, long cpKey)
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
        //public static BaseQuiddityActor GetItem(this List<BaseQuiddityActor> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
