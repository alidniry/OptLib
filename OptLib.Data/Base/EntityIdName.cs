// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 09-26-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="EntityIdName.cs" company="">
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
    /// Id, Name
    /// Active, Lock, Visible
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.EntityId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntity" />
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityId{TEntity}" />
    public abstract class EntityIdName<TEntity>
        : EntityId<TEntity>, IEntity, IId<TEntity>, IEntityId<TEntity>, IEntityIdName<TEntity>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityId<TEntity>.Configuration<TEntityType>
            where TEntityType : EntityIdName<TEntity>
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
        /// Initializes a new instance of the <see cref="EntityIdName{TEntity}" /> class.
        /// </summary>
        public EntityIdName()
            : base()
        {
            this.SetValue("Default");
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdName{TEntity}" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public EntityIdName(string name)
            : base()
        {
            this.SetValue(name);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdName{TEntity}" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public EntityIdName(TEntity id, string name)
            : base(id)
        {
            this.SetValue(name);
        }

        /// <summary>
        /// نام آیتم
        /// </summary>
        /// <value>The name.</value>
        [Required]
        [StringLength(50)]
        [Column(Order = 2, TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="name">The name.</param>
        virtual public void SetValue(string name)
        {
            this.Name = name;
        }
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        virtual public void SetValue(TEntity id, string name)
        {
            base.SetValue (id);
            this.SetValue (name);
        }
    }
}
