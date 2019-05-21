// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-16-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="IEntityId.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace OptLib.Data.Base.Interface
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Id,
    /// CPKey
    /// </summary>
    /// <typeparam name="TKey">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBase" />
    public interface IEntityIdCPKey<TKey>
        : IEntityId<TKey>
    {
        /// <summary>
        /// GS1 Company Prefix Key
        /// </summary>
        /// <value>The identifier.</value>
        long CPKey { get; set; } //0 : فاقد سیستم کدینگ
    }
}