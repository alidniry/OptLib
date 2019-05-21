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
    /// </summary>
    public abstract class HEntityId<TKey>
        : HEntity
    {
        #region Configuration
        public class Configuration<TEntityType>
            : HEntity.Configuration<TEntityType>
            where TEntityType : HEntityId<TKey>
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
        /// Initializes a new instance of the <see cref="EId{TEntity}"/> class.
        /// </summary>
        public HEntityId()
            : base()
        {

        }
        public HEntityId(_History history)
            : base(history)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EId{TEntity}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public HEntityId(TKey id, _History history)
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
