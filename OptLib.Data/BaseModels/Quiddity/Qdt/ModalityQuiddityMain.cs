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

namespace OptLib.Data.BaseModality.Qdt
{
    /// <summary>
    /// چگونگی ماهیت ها
    /// </summary>
    public abstract partial class ModalityQuiddity<TKey, TModalityQdtQuiddity>
        : HEntityBaseIdCPKey<TKey>
        where TModalityQdtQuiddity : ModalityQuiddity<TKey, TModalityQdtQuiddity>
    {
        #region Configuration
        public class Configuration
            : Configuration<TModalityQdtQuiddity>
        {
            public Configuration()
                : base()
            {
                //HasKey(c => new { c.Id, c.CPKey })
                //    ;
                Property(c => c.CPKey)
                    .HasColumnOrder(2)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
            }
        }
        #endregion
        #region Properties
        #endregion
        #region Constructors
        public ModalityQuiddity()
            : base()
        {

        }
        public ModalityQuiddity(_History history)
            : base()
        {
            this.SetValue(history);
        }
        public ModalityQuiddity(TKey id, long cpKey, _History history)
            : base(id, cpKey, history)
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
