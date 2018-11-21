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
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace OptLib.Data.Base
{
    /// <summary>
    /// کلاس اولیه مدلها فقط شامل
    /// Active, Lock, Visible, SuportOtherLanguage
    /// </summary>
    /// <seealso cref="OptLib.Data.Base.IEntity" />
    /// <seealso cref="OptLib.Data.Base.Interface.IEntity" />
    public abstract class Entity 
        : IEntity
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityTypeConfiguration<TEntityType>
            where TEntityType : Entity
        {
            public Configuration()
                 : base()
            {
                Property(c => c.Active).IsRequired();
                Property(c => c.Lock).IsRequired();
                Property(c => c.Visible).IsRequired();
                Property(c => c.SuportOtherLanguage).IsRequired();
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// فعال بودن آیتم.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        //[Required]
        virtual public bool Active { get; set; } = true;
        /// <summary>
        /// قفل بودن آیتم
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        //[Required]
        virtual public bool Lock { get; set; } = false;

        /// <summary>
        /// قابل رویت بودن آیتم.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        //[Required]
        virtual public bool Visible { get; set; } = true;
        /// <summary>
        /// پشتیبانی از داده سایر زبانها.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        //[Required]
        virtual public bool SuportOtherLanguage { get; set; } = true;

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
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity" /> class.
        /// </summary>
        public Entity()
        {

        }
        public Entity(bool active, bool @lock, bool visible, bool suportOtherLanguage)
        {
            this.SetValue(active, @lock, visible, suportOtherLanguage);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void SetValue(bool active, bool @lock, bool visible, bool suportOtherLanguage)
        {
            this.Active = active;
            this.Lock = @lock;
            this.Visible = visible;
            this.SuportOtherLanguage = suportOtherLanguage;
        }
        #endregion
    }
}
