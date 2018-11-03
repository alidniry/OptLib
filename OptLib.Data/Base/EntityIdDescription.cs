// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 09-26-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="EntityIdDescription.cs" company="">
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
    /// کلاس اولیه مدلها فقط شامل
    /// Id, Description
    /// Active, Lock, Visible
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.EntityId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IEntity" />
    /// <seealso cref="OptLib.Data.Base.Interface.IEntityId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IEntityIdDescription{TEntity}" />
    public abstract class EntityIdDescription<TEntity>
        : EntityId<TEntity>, IEntity, IEntityId<TEntity>, IEntityIdDescription<TEntity>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityId<TEntity>.Configuration<TEntityType>
            where TEntityType : EntityIdDescription<TEntity>
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
        /// Initializes a new instance of the <see cref="EntityIdDescription{TEntity}" /> class.
        /// </summary>
        public EntityIdDescription()
            : base()
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdDescription{TEntity}" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public EntityIdDescription(TEntity id)
            : base(id)
        {
            
        }

        /// <summary>
        /// توضیحات آیتم
        /// </summary>
        /// <value>The name.</value>
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }
    }
}
