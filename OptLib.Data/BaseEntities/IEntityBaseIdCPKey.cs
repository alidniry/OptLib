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
using OptLib.Data.Base.Interface;

namespace OptLib.Data.Base
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Id,
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    public interface IEntityBaseIdCPKey<TKey>
        : IEntityBaseId<TKey>
        , IId<TKey>
    {
        /// <summary>
        /// GS1 Company Prefix Key
        /// </summary>
        /// <value>The identifier.</value>
        long CPKey { get; set; }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void SetValue(long cpKey);
    }
}