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

namespace OptLib.Data.BaseModality.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت فعالیتها
    /// </summary>
    public abstract partial class ModalityAction<TKey, TModalityQdtAction>
        : EntityIdCPKeyName<TKey>,
        IEntity, IId<TKey>, IEntityId<TKey>, IEntityIdName<TKey>, IEntityIdCPKeyName<TKey>
        where TModalityQdtAction : ModalityAction<TKey, TModalityQdtAction>
    {
        #region Configuration
        public class Configuration
            : Configuration<TModalityQdtAction>
        {
            public Configuration()
            {
                HasKey(c => new { c.Id, c.CPKey })
                    ;
                Property(c => c.CPKey)
                    .HasColumnOrder(2)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    ;
                Property(c => c.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar")
                    .HasColumnOrder(3)
                    .HasMaxLength(128)
                    ;
            }
        }
        #endregion
        #region Properties
        ///// <summary>
        ///// GS1 Company Prefix Key
        ///// </summary>
        //public long CPKey { get; set; } = 0; //0 : فاقد سیستم کدینگ 

        #endregion
        #region Constructors
        public ModalityAction()
            : base()
        {

        }
        public ModalityAction(string name)
            : base(name)
        {

        }
        public ModalityAction(TKey id, long cpKey, string name)
            : base(id, cpKey, name)
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
        //public static BaseQuiddityAction GetItem(this List<BaseQuiddityAction> list, string name)
        //{
        //    return list.Find(x => x.Name == name);
        //}
    }
}
