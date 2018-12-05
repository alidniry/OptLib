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
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلها فقط شامل
    /// Id
    /// </summary>
    public abstract class EntityId<TKey>
        : Entity, IId<TKey>, IEntityId<TKey>
        //where TEntity : IEquatable<TEntity>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : Entity.Configuration<TEntityType>
            where TEntityType : EntityId<TKey>
        {
            public Configuration()
                : base()
            {
                //HasKey(c => c.Id);
                //HasRequired(c => c.Id);

                //Property(c => c.Id)
                //    //.IsKey()
                //    .IsRequired()
                //    .HasColumnOrder(1)
                //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                //    ;
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
        public virtual TKey Id { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EId{TEntity}"/> class.
        /// </summary>
        public EntityId()
            : base()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EId{TEntity}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public EntityId(TKey id)
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
        public virtual void SetValue(TKey id)
        {
            this.Id = id;
        }
        #endregion
    }
}
