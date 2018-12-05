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
using OptLib.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.BaseModality.Qdt
{
    /// <summary>
    /// ماهیت ها
    /// </summary>
    public abstract partial class ModalityQuiddity<TKey, TModalityQdtQuiddity>
        : EntityBaseId<TKey>,
        IEntityBase, IId<TKey>, IEntityBaseId<TKey>, IHistory
        where TModalityQdtQuiddity : ModalityQuiddity<TKey, TModalityQdtQuiddity>
    {
        #region Configuration
        public class Configuration
            : Configuration<TModalityQdtQuiddity>
        {
            public Configuration()
            {
                HasKey(c => new { c.Id, c.CPKey })
                    ;
                Property(c => c.CPKey)
                    .HasColumnOrder(2)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// GS1 Company Prefix Key
        /// </summary>
        public long CPKey { get; set; } = 0; //0 : فاقد سیستم کدینگ 

        public virtual _History History { get; set; } = new _History();

        #endregion
        #region Constructors
        public ModalityQuiddity()
            : base()
        {

        }
        public ModalityQuiddity(TKey id)
            : base(id)
        {

        }
        public ModalityQuiddity(_History history)
            : base()
        {
            this.SetValue(history);
        }
        public ModalityQuiddity(TKey id, _History history)
            : base(id)
        {
            this.SetValue(history);
        }
        #endregion
        #region Static Methods
        #endregion
        #region Methods
        public void SetValue(_History history)
        {
            this.History = history;
        }
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
