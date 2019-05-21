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

namespace OptLib.Data.BaseModality.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت عاملین
    /// </summary>
    public abstract partial class ModalityActor<TKey, TModalityQdtActor>
        : EntityId/*CPKey*/<TKey>
        where TModalityQdtActor : ModalityActor<TKey, TModalityQdtActor>
    {
        #region Configuration
        public class Configuration
            : Configuration<TModalityQdtActor>
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
        public ModalityActor()
            : base()
        {

        }
        public ModalityActor(TKey id/*, long cpKey*/)
            : base(id/*, cpKey*/)
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
