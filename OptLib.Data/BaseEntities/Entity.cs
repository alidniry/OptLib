// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-08-1397
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="Entity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using OptLib.Data.Base.Interface;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلها فقط شامل
    /// </summary>
    public abstract class Entity
        : IEntity
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityTypeConfiguration<TEntityType>
            where TEntityType : Entity
        {
            public Configuration()
                 : base()
            {
                //Property(c => c.Active).IsRequired();
                //Property(c => c.Lock).IsRequired();
                //Property(c => c.Visible).IsRequired();
                //Property(c => c.SuportOtherLanguage).IsRequired();
            }
        }
        #endregion
        #region Properties
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase" /> class.
        /// </summary>
        public Entity()
        {

        }
        #endregion
        #region Methods
        #endregion
    }
}
