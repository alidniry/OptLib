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
using Optlib.Data.BulkCopy.Mapping;
using OptLib.Data.Base.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلهای شامل
    /// Id, Name
    /// </summary>
    public abstract class EntityIdCPKeyName<TKey>
        : EntityIdCPKey<TKey>, IEntityIdCPKeyName<TKey>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityIdCPKey<TKey>.Configuration<TEntityType>
            where TEntityType : EntityIdCPKeyName<TKey>
        {
            public Configuration()
                : base()
            {
                //Property(c => c.Name)
                //    .IsRequired()
                //    .HasColumnType("nvarchar")
                //    .HasColumnOrder(2)
                //    .HasMaxLength(50)
                //    ;
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
        /// نام آیتم
        /// </summary>
        /// <value>The name.</value>
        //[Required]
        //[StringLength(50)]
        //[Column(Order = 2, TypeName = "nvarchar")]
        [ModelMap]
        public string Name { get; set; } = "Default";
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdName{TEntity}" /> class.
        /// </summary>
        public EntityIdCPKeyName()
            : base()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdName{TEntity}" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public EntityIdCPKeyName(string name)
            : base()
        {
            this.SetValue(name);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseIdName{TEntity}" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public EntityIdCPKeyName(TKey id, long cpKey, string name)
            : base(id, cpKey)
        {
            this.SetValue(name);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="name">The name.</param>
        virtual public void SetValue(string name)
        {
            this.Name = name;
        }
        #endregion
    }
}
