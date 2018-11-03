// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-16-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="eHistoryLog.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// عملیاتها
/// </summary>
public enum eHistoryLog : short
{
    /// <summary>
    /// ایجاد آیتم
    /// </summary>
    CREATE = 1,
    /// <summary>
    /// حذف آیتم
    /// </summary>
    DELETE,
    /// <summary>
    /// تغییر آیتم
    /// </summary>
    CHANGE,
    /// <summary>
    /// تغییر آیتم : قدیم
    /// </summary>
    CHANGE_OLD,
    /// <summary>
    /// تغییر آیتم : جدید
    /// </summary>
    CHANGE_NEW,
}