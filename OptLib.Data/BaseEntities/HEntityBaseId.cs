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
using Optlib.Data.BulkCopy.Mapping;
using OptLib.Data.ComplexType;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلها فقط شامل
    /// Id
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    /// <typeparam name="TKey">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.EntityBase" />
    /// <seealso cref="OptLib.Data.Base.IEntityBase" />
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseId{TEntity}" />
    public abstract class HEntityBaseId<TKey>
        : HEntityBase
    {
        #region Configuration
        public class Configuration<TEntityType>
            : HEntityBase.Configuration<TEntityType>
            where TEntityType : HEntityBaseId<TKey>
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
        #endregion
        #region Properties
        /// <summary>
        /// کد اصلی.
        /// </summary>
        /// <value>The identifier.</value>
        //[Key]
        //[Required]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ModelMap]
        public virtual TKey Id { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseId{TEntity}"/> class.
        /// </summary>
        public HEntityBaseId()
            : base()
        {

        }
        public HEntityBaseId(_History history)
            : base(history)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseId{TEntity}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public HEntityBaseId(TKey id, _History history)
            : base(history)
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
