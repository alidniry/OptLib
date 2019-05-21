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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلها
    /// </summary>
    public abstract class _Entity
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityTypeConfiguration<TEntityType>
            where TEntityType : _Entity
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
        #region Properties abstract
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase" /> class.
        /// </summary>
        public _Entity()
        {

        }
        #endregion
        #region Methods
        #endregion
    }
}
