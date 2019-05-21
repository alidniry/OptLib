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
using Optlib.Data.BulkCopy.Mapping;
using OptLib.Data.Base;
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using OptLib.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.BaseModels
{
    /// <summary>
    /// ماهیت عاملین
    /// HEntityBaseIdCPKeyName
    /// </summary>
    public abstract partial class BaseQuiddityActor<TKey>
        : HEntityBaseIdCPKeyName<TKey>
    {
        #region Configuration
        public class Configuration<TEntityType>
            : HEntityBaseIdCPKey<TKey>.Configuration<TEntityType>
            where TEntityType : BaseQuiddityActor<TKey>
        {
            public Configuration()
                : base()
            {
                //HasKey(c => new { c.Id, c.CPKey })
                //    ;
                //Property(c => c.CPKey)
                //    .HasColumnOrder(2)
                //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                //    ;
                //Property(c => c.Name)
                //    .HasColumnOrder(3)
                //    ;

            }
        }
        #endregion
        #region Properties
        #endregion
        #region Constructors
        public BaseQuiddityActor()
            : base()
        {
        }
        public BaseQuiddityActor(TKey id, long cpKey, string name, _History history)
            : base(id, cpKey, name, history)
        {
        }
        #endregion
        #region Static Methods
        #endregion
        #region Methods
        #endregion
    }
}
namespace OptLib.Data.Models.ExtensionMethods
{
    public static partial class ModelsExtensions
    {
        //public static BaseQuiddity GetItem(this List<BaseQuiddity> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
