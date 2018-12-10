// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-16-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="IEntityIdDescription.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base.Interface;

namespace OptLib.Data.Base
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Id, Description
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    /// <typeparam name="TKey">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IDescription" />
    /// <seealso cref="OptLib.Data.Base.IEntityBase" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseId{TEntity}" />
    public interface IEntityBaseIdCPKeyDescription<TKey>
        : IEntityBase
        , IId<TKey>, IDescription
        , IEntityBaseId<TKey>
        , IEntityBaseIdCPKey<TKey>
    {
        /// <summary>
        /// توضیحات آیتم
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }
    }
}