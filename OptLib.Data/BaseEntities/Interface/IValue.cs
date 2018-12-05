// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-16-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="IValue.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OptLib.Data.Base.Interface
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Value
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public interface IValue<TEntity>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        TEntity Value { get; set; }
    }
}