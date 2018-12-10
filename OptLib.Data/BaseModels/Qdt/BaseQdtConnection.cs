// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="BaseQuiddityConnection.cs" company="">
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
using OptLib.Data.BaseModality.Qdt.Quiddity;
using OptLib.Data.BaseModality.Qdt;

namespace OptLib.Data.BaseModels.Qdt
{
    /// <summary>
    /// ماهیت اتصال تماس
    /// </summary>
    public abstract partial class BaseQdtConnection<TModalityQdtConnection>
        : EntityBaseIdCPKey<long>,
        IEntity, IId<long>, IEntityId<long>, IEntityBase, IEntityBaseId<long>, IEntityBaseIdCPKey<long>, IHistory
        where TModalityQdtConnection : BaseQdtConnection<TModalityQdtConnection>
    {
        #region Configuration
        public class Configuration
            : Configuration<TModalityQdtConnection>
        {
            public Configuration()
            {
                HasKey(c => new { c.Id, c.CPKey })
                    ;
                Property(c => c.Id)
                    .IsRequired()
                    .HasColumnOrder(1)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
                Property(c => c.CPKey)
                    .HasColumnOrder(2)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
            }
        }
        #endregion /Configuration
        #region Properties
        /// <summary>
        /// GS1 Company Prefix Key
        /// </summary>
        public long CPKey { get; set; } = 0; //0 : فاقد سیستم کدینگ 

        public virtual _History History { get; set; } = new _History();

        #endregion
        #region Constructors
        public BaseQdtConnection()
            : base()
        {

        }
        public BaseQdtConnection(long id, long cpKey)
            : base(id, cpKey)
        {

        }
        public BaseQdtConnection(_History history)
            : base()
        {
            this.SetValue(history);
        }
        public BaseQdtConnection(long id, long cpKey, _History history)
            : base(id, cpKey)
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
        //public static BaseQuiddityConnection GetItem(this List<BaseQuiddityConnection> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
