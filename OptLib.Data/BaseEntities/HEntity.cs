// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-08-1397
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="Entity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using Optlib.Data.BulkCopy.Mapping;
using OptLib.Data.ComplexType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلها فقط شامل
    /// </summary>
    public abstract class HEntity
        : _Entity
    {
        #region Configuration
        public class Configuration<TEntityType>
            : _Entity.Configuration<TEntityType>
            where TEntityType : HEntity
        {
            public Configuration()
                 : base()
            {
                Property(c => c.History.CreateID)
                    .IsRequired();
                Property(c => c.History.CreateDate)
                    .IsRequired();
                Property(c => c.History.LastChangesID)
                    .IsRequired();
                Property(c => c.History.LastChangesDate)
                    .IsRequired();
                Property(c => c.History.DEL)
                    .IsRequired();
                Property(c => c.History.UnChangeable)
                    .IsRequired();
                Property(c => c.History.NonRemovable)
                    .IsRequired();
            }
        }
        #endregion
        #region Properties
        public virtual _History History { get; set; } = new _History();
        #region _History
        [NotMapped]
        [ModelMap("History_CreateID")]
        public int History_CreateID { get { return History.CreateID; } set { History.CreateID = value; } }
        [NotMapped]
        [ModelMap("History_CreateDate")]
        public DateTime History_CreateDate { get { return History.CreateDate; } set { History.CreateDate = value; } }
        [NotMapped]
        [ModelMap("History_LastChangesID")]
        public int History_LastChangesID { get { return History.LastChangesID; } set { History.LastChangesID = value; } }
        [NotMapped]
        [ModelMap("History_LastChangesDate")]
        public DateTime History_LastChangesDate { get { return History.LastChangesDate; } set { History.LastChangesDate = value; } }
        [NotMapped]
        [ModelMap("History_DEL")]
        public bool History_DEL { get { return History.DEL; } set { History.DEL = value; } }
        [NotMapped]
        [ModelMap("History_DeleteID")]
        public int? History_DeleteID { get { return History.DeleteID; } set { History.DeleteID = value; } }
        [NotMapped]
        [ModelMap("History_DeleteDate")]
        public DateTime? History_DeleteDate { get { return History.DeleteDate; } set { History.DeleteDate = value; } }
        [NotMapped]
        [ModelMap("History_UnChangeable")]
        public bool History_UnChangeable { get { return History.UnChangeable; } set { History.UnChangeable = value; } }
        [NotMapped]
        [ModelMap("History_NonRemovable")]
        public bool History_NonRemovable { get { return History.NonRemovable; } set { History.NonRemovable = value; } }
        #endregion

        #endregion
        #region Properties abstract
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase" /> class.
        /// </summary>
        public HEntity()
        {

        }
        public HEntity(_History history)
        {
            this.SetValue(history);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void SetValue(_History history)
        {
            this.History = history;
        }
        #endregion
    }
}
