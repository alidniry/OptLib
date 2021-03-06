﻿// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-16-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="IEntityIdValueName.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base.Interface;

namespace OptLib.Data.Base
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Id, Name, Value,
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    public interface IEntityBaseIdValueName<TKey, TValue>
         : IEntityBase
        , IId<TKey>, IName, IValue<TValue>
        , IEntityBaseId<TKey>, IEntityBaseIdName<TKey>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        TValue Value { get; set; }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        void SetValue(TValue value);
    }
}