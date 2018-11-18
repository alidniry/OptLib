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

namespace OptLib.Data.BaseModels
{
    /// <summary>
    /// ماهیت فعالیتها
    /// </summary>
    public abstract partial class BaseQuiddityAction<TEntity>
        : EntityIdName<TEntity>, IHistory
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityIdName<TEntity>.Configuration<TEntityType>
            where TEntityType : BaseQuiddityAction<TEntity>
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

        public BaseQuiddityAction()
        {

        }

        public _History History { get; set; } = new _History();
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
