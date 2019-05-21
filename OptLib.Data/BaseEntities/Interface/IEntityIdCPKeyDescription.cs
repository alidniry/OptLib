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
    /// CPKey, Description
    /// </summary>
    /// <typeparam name="TKey">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBase" />
    public interface IEntityIdCPKeyDescription<TKey>
        : IEntityIdCPKey<TKey>
    {
        /// <summary>
        /// توضیحات آیتم
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }
    }
}