// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-06-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="EntityIdValueNameDescription.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using Optlib.Data.BulkCopy.Mapping;
using OptLib.Data.Base.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلهای شامل
    /// Id, Name, Value, Description,
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    /// <typeparam name="TKey">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.EntityBaseIdNameDescription{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBase" />
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IName" />
    /// <seealso cref="OptLib.Data.Base.IDescription" />
    /// <seealso cref="OptLib.Data.Base.Interface.IValue{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseIdName{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseIdNameDescription{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseIdValueName{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseIdValueNameDescription{TEntity}" />
    public abstract class EntityBaseIdValueNameDescription<TKey, TValue>
        : EntityBaseIdNameDescription<TKey>
        , IEntityBase, IId<TKey>, IName, IDescription, IValue<TValue>
        , IEntityBaseId<TKey>, IEntityBaseIdName<TKey>, IEntityBaseIdNameDescription<TKey>, IEntityBaseIdValueName<TKey, TValue>, IEntityBaseIdValueNameDescription<TKey, TValue>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityBaseIdNameDescription<TKey>.Configuration<TEntityType>
            where TEntityType : EntityBaseIdValueNameDescription<TKey, TValue>
        {
            public Configuration()
            {
                //Property(c => c.Value).IsRequired();

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
        /// ایتم مقدار
        /// </summary>
        /// <value>The name.</value>
        //[Required]
        [ModelMap]
        public TValue Value { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdValueNameDescription{TEntity}"/> class.
        /// </summary>
        public EntityBaseIdValueNameDescription()
            : base()
        {
            SetValue(Id);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdValueNameDescription{TEntity}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public EntityBaseIdValueNameDescription(TValue value, string name)
            : base(name)
        {
            SetValue(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdValueNameDescription{TEntity}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public EntityBaseIdValueNameDescription(TKey id, TValue value, string name)
            : base(id, name)
        {
            SetValue(value);
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
