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
using OptLib.Data.BaseModality.Qdt.Quiddity;
using OptLib.Data.BaseModality.Qdt;

namespace OptLib.Data.BaseModels.Qdt
{
    /// <summary>
    /// ماهیت ارتباطات داده ای
    /// </summary>
    public abstract partial class BaseQdtRelation<TModalityQdtRelation>
        : EntityBaseId<long>
        where TModalityQdtRelation : BaseQdtRelation<TModalityQdtRelation>
    {
        #region Configuration
        public class Configuration
            : Configuration<TModalityQdtRelation>
        {
            public Configuration()
                 : base()
            {
                //HasKey(c => new { c.Id, c.CPKey })
                //    ;
                Property(c => c.Id)
                    .IsRequired()
                    .HasColumnOrder(1)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
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

        public virtual _History History { get; set; } = new _History();
        #endregion
        #region Constructors
        public BaseQdtRelation()
            : base()
        {

        }
        public BaseQdtRelation(long id/*, long cpKey*/)
            : base(id/*, cpKey*/)
        {

        }
        public BaseQdtRelation(_History history)
            : base()
        {
            this.SetValue(history);
        }
        public BaseQdtRelation(long id/*, long cpKey*/, _History history)
            : base(id/*, cpKey*/)
        {
            this.SetValue(history);
        }
        #endregion
        #region Static Methods
        #endregion
        #region Methods
        public void SetValue(string name)
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
        //public static BaseQuiddityRelation GetItem(this List<BaseQuiddityRelation> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
