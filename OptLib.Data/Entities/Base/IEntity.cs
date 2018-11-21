// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-08-1397
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="IEntity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace OptLib.Data.Base
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// فعال بودن آیتم.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>true</c>.</value>
        bool Active { get; set; }

        /// <summary>
        /// قفل بودن آیتم.
        /// </summary>
        /// <value><c>true</c> if lock; otherwise, <c>false</c>.</value>
        bool Lock { get; set; }

        /// <summary>
        /// قابل رویت بودن آیتم.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>true</c>.</value>
        bool Visible { get; set; }

        /// <summary>
        /// وضعیت اعتبار
        /// </summary>
        /// <value><c>true</c> if Valid; otherwise, <c>true</c>.</value>
        //bool Valid { get; set; }

        /// <summary>
        /// قابل نمایش بودن آیتم.
        /// </summary>
        /// <value><c>true</c> if ItemDisplayable; otherwise, <c>true</c>.</value>
        //bool ItemDisplayable { get; set; }

        /// <summary>
        /// پشتیبانی از داده سایر زبانها.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        //[Required]
        bool SuportOtherLanguage { get; set; }
    }
}