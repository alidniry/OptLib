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
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.BaseModels.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت فعالیتها
    /// </summary>
    public abstract partial class BaseQuiddityAction<TEntity>
        : BaseQuiddityMain<TEntity>
        where TEntity : BaseQuiddityMain<TEntity>
    {
        #region Configuration
        public class Configuration
            : ModalityAction<long, TModalityQdtAction>.Configuration
        {
            public Configuration()
            {
                Property(c => c.Id)
                    .IsRequired()
                    .HasColumnOrder(1)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
            }
        }
        #endregion
        #region Properties
        public virtual TModalityQdtQuiddity Quiddity { get; set; }
        #endregion
        #region Constructors
        public BaseQuiddityAction()
            : base()
        {
            SetValue(string name)
        }
        public BaseQuiddityAction(long id, long cpKey, string name, _History history)
            : base(id, cpKey, history)
        {

        }
        #endregion
        #region Static Methods
        #endregion
        #region Methods
        public void SetValue(string name)
        {
            this.Name = name;
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
