// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 09-26-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="EntityIdNameDescription.cs" company="">
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
    /// رابط کلاس اولیه مدلهای شامل
    /// Id, Name, Description
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    /// <typeparam name="TKey">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.IEntityBaseIdNameDescription{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBase" />
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IName" />
    /// <seealso cref="OptLib.Data.Base.IDescription" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseIdName{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.EntityBaseIdName{TEntity}" />
    public abstract class EntityBaseIdNameDescription<TKey>
        : EntityBaseIdName<TKey>, IEntityBase, IId<TKey>, IName, IDescription, IEntityBaseId<TKey>, IEntityBaseIdName<TKey>, IEntityBaseIdNameDescription<TKey>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityBaseIdName<TKey>.Configuration<TEntityType>
            where TEntityType : EntityBaseIdNameDescription<TKey>
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
        #endregion /Configuration
        #region Properties
        /// <summary>
        /// توضیحات ایتم
        /// </summary>
        /// <value>The name.</value>
        //[StringLength(255)]
        //[Column(TypeName = "nvarchar")]
        public string Description { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdNameDescription{TEntity}" /> class.
        /// </summary>
        public EntityBaseIdNameDescription()
            : base()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdNameDescription{TEntity}" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public EntityBaseIdNameDescription(string name)
            : base(name)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdNameDescription{TEntity}" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public EntityBaseIdNameDescription(TKey id, string name)
            : base(id, name)
        {

        }
        #endregion
    }
}
