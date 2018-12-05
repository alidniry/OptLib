// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-16-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="IEntityIdValueNameDescription.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base.Interface;

namespace OptLib.Data.Base
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Id, Name, Value, Description,
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    public interface IEntityBaseIdValueNameDescription<TKey, TValue>
        : IEntityBase, IId<TKey>, IName, IDescription, IValue<TValue>
        , IEntityBaseId<TKey>, IEntityBaseIdName<TKey>, IEntityBaseIdNameDescription<TKey>, IEntityBaseIdValueName<TKey, TValue>
    {
        /// <summary>
        /// آیتم مقدار
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