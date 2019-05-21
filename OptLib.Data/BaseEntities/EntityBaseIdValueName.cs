// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-06-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="EntityIdValueName.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Optlib.Data.BulkCopy.Mapping;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلهای شامل
    /// Id, Name, Value,
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    /// <typeparam name="TKey">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.IEntityBaseIdValueName{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.EntityBaseIdName{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBase" />
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IName" />
    /// <seealso cref="OptLib.Data.Base.Interface.IValue{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseIdName{TEntity}" />
    public abstract class EntityBaseIdValueName<TKey, TValue>
        : EntityBaseIdName<TKey>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityBaseIdName<TKey>.Configuration<TEntityType>
            where TEntityType : EntityBaseIdValueName<TKey, TValue>
        {
            public Configuration()
                : base()
            {
                //Property(c => c.Id)
                //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                //    .HasColumnOrder(5)
                //    ;
                //Property(c => c.Name)
                //    .HasColumnOrder(6)
                //    ;
                //Property(current => current.Name)
                //    .HasMaxLength(25)
                //    ;
            }

        }
        #endregion /Configuration
        #region Properties
        /// <summary>
        /// آیتم مقدار
        /// </summary>
        /// <value>The name.</value>
        //[Required]
        [ModelMap]
        public TValue Value { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdValueName{TEntity}" /> class.
        /// </summary>
        public EntityBaseIdValueName()
            : base()
        {
            this.SetValue(Id);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdValueName{TEntity}" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public EntityBaseIdValueName(string name)
            : base(name)
        {
            this.SetValue(Id);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdValueName{TEntity}" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public EntityBaseIdValueName(TValue value, string name)
            : base(name)
        {
            this.SetValue(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdValueName{TEntity}" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public EntityBaseIdValueName(TKey id, TValue value, string name)
            : base(id, name)
        {
            this.SetValue(value);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        virtual public void SetValue(TValue value)
        {
            this.Value = value;
        }
        #endregion
    }
}
