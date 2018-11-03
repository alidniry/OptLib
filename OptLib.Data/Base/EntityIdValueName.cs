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
using OptLib.Data.Base.Interface;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلهای شامل
    /// Id, Name, Value,
    /// Active, Lock, Visible
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.IEntityIdValueName{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.EntityIdName{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntity" />
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IName" />
    /// <seealso cref="OptLib.Data.Base.Interface.IValue{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityIdName{TEntity}" />
    public abstract class EntityIdValueName<TEntity>
        : EntityIdName<TEntity>, IEntity, IId<TEntity>, IName, IValue<TEntity>, IEntityId<TEntity>, IEntityIdName<TEntity>, IEntityIdValueName<TEntity>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityIdName<TEntity>.Configuration<TEntityType>
            where TEntityType : EntityIdValueName<TEntity>
        {
            public Configuration()
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

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdValueName{TEntity}" /> class.
        /// </summary>
        public EntityIdValueName()
            : base()
        {
            this.SetValue(Id);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdValueName{TEntity}" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public EntityIdValueName(string name)
            : base(name)
        {
            this.SetValue(Id);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdValueName{TEntity}" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public EntityIdValueName(TEntity value, string name)
            : base(name)
        {
            this.SetValue(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdValueName{TEntity}" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public EntityIdValueName(TEntity id, TEntity value, string name)
            : base(id, name)
        {
            this.SetValue(value);
        }

        /// <summary>
        /// آیتم مقدار
        /// </summary>
        /// <value>The name.</value>
        [Required]
        public TEntity Value { get; set; }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        virtual public void SetValue(TEntity value)
        {
            this.Value = value;
        }
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        virtual public void SetValue(TEntity id, TEntity value, string name)
        {
            base.SetValue (id);
            this.SetValue (name);
        }
    }
}
