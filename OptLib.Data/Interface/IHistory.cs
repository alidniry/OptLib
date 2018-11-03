// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-08-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-08-1397
// ***********************************************************************
// <copyright file="_IHistory.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.ComplexType;

namespace OptLib.Data.Interface
{
    /// <summary>
    /// رابط تاریخچه
    /// </summary>
    public interface IHistory
    {
        /// <summary>
        /// افزودن کلاس افزایشی فاعلیت
        /// </summary>
        /// <value>The h log.</value>
        _History History { get; set; }
    }
}