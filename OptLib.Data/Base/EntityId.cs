// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-04-1397
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="bId.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلها فقط شامل
    /// Id
    /// Active, Lock, Visible
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.Entity" />
    /// <seealso cref="OptLib.Data.Base.IEntity" />
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityId{TEntity}" />
    public abstract class EntityId<TEntity>
        : Entity, IEntity, IId<TEntity>, IEntityId<TEntity>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : Entity.Configuration<TEntityType>
            where TEntityType : EntityId<TEntity>
        {
            public Configuration()
                : base()
            {
            }
        }
        #endregion /Configuration
        #region Properties
        /// <summary>
        /// کد اصلی.
        /// </summary>
        /// <value>The identifier.</value>
        //[Key]
        //[Required]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public TEntity Id { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityId{TEntity}"/> class.
        /// </summary>
        public EntityId()
            : base()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityId{TEntity}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public EntityId(TEntity id)
            : base()
        {
            this.SetValue(id);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void SetValue(TEntity id)
        {
            this.Id = id;
        }
        #endregion
    }
}
