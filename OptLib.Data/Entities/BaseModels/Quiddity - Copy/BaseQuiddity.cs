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
    /// ماهیت ها
    /// </summary>
    public abstract partial class BaseQuiddity
        : EntityId<long>,
        IEntity, IId<long>, IEntityId<long>, IHistory
    {
        #region Configuration
        public class Configuration<TEntityType>
            : EntityId<long>.Configuration<TEntityType>
            where TEntityType : BaseQuiddity
        {
            public Configuration()
            {

            }

        }
        #endregion /Configuration
        #region Properties
        public _History History { get; set; } = new _History();
        virtual public BaseQuiddityAction BaseQuiddityAction { get; set; }
        #endregion
        #region Constructors
        public BaseQuiddity()
            : base()
        {

        }
        public BaseQuiddity(long id)
            : base(id)
        {

        }
        public BaseQuiddity(_History history)
            : base()
        {
            this.SetValue(history);
        }
        public BaseQuiddity(long id, _History history)
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
