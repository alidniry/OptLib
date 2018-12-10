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
using OptLib.Data.BaseModality.Qdt;
using OptLib.Data.BaseModality.Qdt.Quiddity;
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.BaseModels.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت فعالیتها
    /// </summary>
    public abstract partial class BaseQdtAction<TModalityQdtQuiddity, TModalityQdtAction>
        : ModalityAction<long, TModalityQdtAction>,
        IEntity, IId<long>, IEntityId<long>, IEntityIdName<long>
        where TModalityQdtQuiddity : ModalityQuiddity<long, TModalityQdtQuiddity>
        where TModalityQdtAction : ModalityAction<long, TModalityQdtAction>
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
        public BaseQdtAction()
            : base()
        {

        }
        public BaseQdtAction(string name)
            : base(name)
        {

        }
        public BaseQdtAction(long id, long cpKey, string name)
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
