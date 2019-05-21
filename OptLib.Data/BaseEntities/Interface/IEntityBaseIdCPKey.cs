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
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    public interface IEntityBaseIdCPKey<TKey>
        : IEntityBaseId<TKey>
    {
        /// <summary>
        /// GS1 Company Prefix Key
        /// </summary>
        /// <value>The identifier.</value>
        long CPKey { get; set; }
    }
}