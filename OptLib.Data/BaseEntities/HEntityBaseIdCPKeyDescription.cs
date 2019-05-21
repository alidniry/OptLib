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
using Optlib.Data.BulkCopy.Mapping;
using OptLib.Data.ComplexType;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلها فقط شامل
    /// Id, Description
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    /// <typeparam name="TKey">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.EntityBaseId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IEntity" />
    /// <seealso cref="OptLib.Data.Base.Interface.IEntityId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IEntityIdDescription{TEntity}" />
    public abstract class HEntityBaseIdCPKeyDescription<TKey>
        : HEntityBaseIdCPKey<TKey>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : HEntityBaseIdCPKey<TKey>.Configuration<TEntityType>
            where TEntityType : HEntityBaseIdCPKeyDescription<TKey>
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
        #endregion
        #region Properties
        /// <summary>
        /// توضیحات آیتم
        /// </summary>
        /// <value>The name.</value>
        //[StringLength(255)]
        //[Column(TypeName = "nvarchar")]
        [ModelMap]
        public string Description { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdDescription{TEntity}" /> class.
        /// </summary>
        public HEntityBaseIdCPKeyDescription()
            : base()
        {

        }
        public HEntityBaseIdCPKeyDescription(_History history)
            : base(history)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdDescription{TEntity}" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public HEntityBaseIdCPKeyDescription(TKey id, long cpKey, _History history)
            : base(id, cpKey, history)
        {

        }
        #endregion
        #region Methods
        #endregion
    }
}
