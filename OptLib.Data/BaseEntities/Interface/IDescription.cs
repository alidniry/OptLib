// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-08-1397
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="IDescription.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OptLib.Data.Base
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Description
    /// </summary>
    public interface IDescription
    {
        /// <summary>
        /// توضیحات آیتم
        /// </summary>
        /// <value>The name.</value>
        string Description { get; set; }
    }
}