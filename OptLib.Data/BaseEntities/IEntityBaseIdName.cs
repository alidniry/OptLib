// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-16-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="IEntityIdName.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base.Interface;

namespace OptLib.Data.Base
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Id, Name
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    /// <typeparam name="TKey">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IName" />
    /// <seealso cref="OptLib.Data.Base.IEntityBase" />
    /// <seealso cref="OptLib.Data.Base.IEntityBaseId{TEntity}" />
    public interface IEntityBaseIdName<TKey>
        : IEntityBase
        , IId<TKey>, IName
        , IEntityBaseId<TKey>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="name">The name.</param>
        void SetValue(string name);
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        void SetValue(TKey id, string name);
    }
}