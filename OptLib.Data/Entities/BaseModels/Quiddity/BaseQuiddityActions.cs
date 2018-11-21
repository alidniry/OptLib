// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 07-10-1397
//
// Last Modified By : alidniry
// Last Modified On : 07-10-1397
// ***********************************************************************
// <copyright file="QuiddityAction.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base;
using OptLib.Data.Base.Interface;
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.BaseModels
{
    /// <summary>
    /// ماهیت فعالیتها
    /// </summary>
    public abstract partial class BaseQuiddityAction
        : BaseQuiddity,
        IEntity, IId<long>, IEntityId<long>, IEntityIdName<long>, IHistory
    {
        #region Configuration
        public class Configuration<TEntityType>
            : BaseQuiddity.Configuration<TEntityType>
            where TEntityType : BaseQuiddityAction
        {
            public Configuration()
            {
                Property(c => c.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar")
                    .HasColumnOrder(2)
                    .HasMaxLength(128)
                    ;
            }

        }
        #endregion /Configuration
        #region Properties
        /// <summary>
        /// نام آیتم
        /// </summary>
        /// <value>The name.</value>
        //[Required]
        //[StringLength(50)]
        //[Column(Order = 2, TypeName = "nvarchar")]
        public virtual string Name { get; set; }
        #endregion
        #region Constructors
        public BaseQuiddityAction()
            : base()
        {

        }
        public BaseQuiddityAction(_History history)
            : base()
        {
            this.SetValue(history);
        }
        public BaseQuiddityAction(string name)
            : base()
        {
            this.SetValue(name);
        }
        public BaseQuiddityAction(string name, _History history)
            : base()
        {
            this.SetValue(name);
            this.SetValue(history);
        }
        public BaseQuiddityAction(long id, string name)
            : base(id)
        {
            this.SetValue(name);
        }
        public BaseQuiddityAction(long id, string name, _History history)
            : base(id)
        {
            this.SetValue(name);
            this.SetValue(history);
        }
        #endregion
        #region Static Methods
        #endregion
        #region Methods
        public void SetValue(string name)
        {
            this.Name = name;
        }

        public void SetValue(long id, string name)
        {
            this.Id = id;
            this.SetValue(name);
        }
        #endregion
    }
}
namespace OptLib.Data.Models.ExtensionMethods
{
    public static partial class ModelsExtensions
    {
        //public static BaseQuiddityAction GetItem(this List<BaseQuiddityAction> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
