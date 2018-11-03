// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-08-1397
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="Entity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using OptLib.Data.Base.Interface;
using System.ComponentModel.DataAnnotations;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلها فقط شامل
    /// Active, Lock, Visible
    /// </summary>
    /// <seealso cref="OptLib.Data.Base.IEntity" />
    /// <seealso cref="OptLib.Data.Base.Interface.IEntity" />
    public abstract class Entity 
        : IEntity
    {
        #region Configuration
        public class Configuration<TEntityType>
            : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TEntityType>
            where TEntityType : Entity
        {
            public Configuration()
            {
                //Property(c => c.Id)
                //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                //    .HasColumnOrder(5)
                //    ;
                //Property(c => c.Name)
                //    .HasColumnOrder(6)
                //    ;
                //Property(current => current.Name)
                //    .HasMaxLength(25)
                //    ;
            }

        }
        #endregion /Configuration

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity" /> class.
        /// </summary>
        public Entity()
        {

        }
        /// <summary>
        /// فعال بودن آیتم.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [Required]
        virtual public bool Active { get; set; } = true;
        /// <summary>
        /// قفل بودن آیتم
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [Required]
        virtual public bool Lock { get; set; } = false;

        /// <summary>
        /// قابل رویت بودن آیتم.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [Required]
        virtual public bool Visible { get; set; } = true;

        /// <summary>
        /// وضعیت اعتبار
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        //[Required]
        //virtual public bool Valid { get; set; } = true;

        /// <summary>
        /// قابل نمایش بودن آیتم.
        /// </summary>
        //[Required]
        //virtual public bool ItemDisplayable { get; set; } = true;
    }
}
