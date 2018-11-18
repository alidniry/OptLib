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
using OptLib.Data.Base.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلهای شامل
    /// Id, Name, Value, Description,
    /// Active, Lock, Visible
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.EntityIdNameDescription{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntity" />
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IName" />
    /// <seealso cref="OptLib.Data.Base.IDescription" />
    /// <seealso cref="OptLib.Data.Base.Interface.IValue{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityIdName{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityIdNameDescription{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityIdValueName{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityIdValueNameDescription{TEntity}" />
    public abstract class EntityIdValueNameDescription<TEntity>
        : EntityIdNameDescription<TEntity>
        , IEntity, IId<TEntity>, IName, IDescription, IValue<TEntity>
        , IEntityId<TEntity>, IEntityIdName<TEntity>, IEntityIdNameDescription<TEntity>, IEntityIdValueName<TEntity>, IEntityIdValueNameDescription<TEntity>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityIdNameDescription<TEntity>.Configuration<TEntityType>
            where TEntityType : EntityIdValueNameDescription<TEntity>
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
        public TEntity Value { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdValueNameDescription{TEntity}"/> class.
        /// </summary>
        public EntityIdValueNameDescription()
            : base()
        {
            SetValue(Id);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdValueNameDescription{TEntity}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public EntityIdValueNameDescription(string name)
            : base(name)
        {
            SetValue(Id);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdValueNameDescription{TEntity}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public EntityIdValueNameDescription(TEntity value, string name)
            : base(name)
        {
            SetValue(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdValueNameDescription{TEntity}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public EntityIdValueNameDescription(TEntity id, TEntity value, string name)
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
        virtual public void SetValue(TEntity value)
        {
            this.Value = value;
        }
        /// <summary>
        /// آیتم مقدار
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        virtual public void SetValue(TEntity id, TEntity value, string name)
        {
            base.SetValue(id);
            this.SetValue(name);
        }
        #endregion
    }
}
