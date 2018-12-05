// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-16-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="IEntityIdNameDescription.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base.Interface;

namespace OptLib.Data.Base
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Id, Name, Description
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    /// <typeparam name="TKey">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.IEntityBase" />
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IName" />
    /// <seealso cref="OptLib.Data.Base.IDescription" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseIdName{TEntity}" />
    public interface IEntityBaseIdNameDescription<TKey>
        : IEntityBase
        , IId<TKey>, IName, IDescription
        , IEntityBaseId<TKey>, IEntityBaseIdName<TKey>

    {
        /// <summary>
        /// توضیحات ایتم
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }
    }
}