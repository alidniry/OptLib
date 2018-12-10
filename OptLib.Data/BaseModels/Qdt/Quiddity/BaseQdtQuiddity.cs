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
using OptLib.Data.ComplexType;
using OptLib.Data.Interface;
using OptLib.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.BaseModels.Qdt.Quiddity
{
    /// <summary>
    /// ماهیت ها
    /// </summary>
    public abstract partial class BaseQdtQuiddity<TModalityQdtQuiddity, TModalityQdtAction, TModalityQdtActor, TModalityQdtAllocationResource, TModalityQdtObject, TModalityQdtPosition, TModalityQdtService>
        : ModalityQuiddity<long, TModalityQdtQuiddity>,
        IEntityBase, IId<long>, IEntityBaseId<long>, IHistory
        where TModalityQdtQuiddity : BaseQdtQuiddity<TModalityQdtQuiddity, TModalityQdtAction, TModalityQdtActor, TModalityQdtAllocationResource, TModalityQdtObject, TModalityQdtPosition, TModalityQdtService>
        where TModalityQdtAction : BaseQdtAction<TModalityQdtQuiddity, TModalityQdtAction>
        where TModalityQdtActor : BaseQdtActor<TModalityQdtQuiddity, TModalityQdtActor>
        where TModalityQdtAllocationResource : BaseQdtAllocationResource<TModalityQdtQuiddity, TModalityQdtAllocationResource>
        where TModalityQdtObject : BaseQdtObject<TModalityQdtQuiddity, TModalityQdtObject>
        where TModalityQdtPosition : BaseQdtPosition<TModalityQdtQuiddity, TModalityQdtPosition>
        where TModalityQdtService : BaseQdtService<TModalityQdtQuiddity, TModalityQdtService>
    {
        #region Configuration
        public class Configuration
            : ModalityQuiddity<long, TModalityQdtQuiddity>.Configuration
        {
            public Configuration()
            {
                //one - to - one
                HasOptional(c => c.QdtAction)
                   .WithRequired(c => c.Quiddity)
                   .WillCascadeOnDelete(true)
                   ;
                //one - to - one
                HasOptional(c => c.QdtActor)
                   .WithRequired(c => c.Quiddity)
                   .WillCascadeOnDelete(true)
                   ;
                //one - to - one
                HasOptional(c => c.QdtAllocationResource)
                   .WithRequired(c => c.Quiddity)
                   .WillCascadeOnDelete(true)
                   ;
                //one - to - one
                HasOptional(c => c.QdtObject)
                   .WithRequired(c => c.Quiddity)
                   .WillCascadeOnDelete(true)
                   ;
                //one - to - one
                HasOptional(c => c.QdtPosition)
                   .WithRequired(c => c.Quiddity)
                   .WillCascadeOnDelete(true)
                   ;
                //one - to - one
                HasOptional(c => c.QdtService)
                   .WithRequired(c => c.Quiddity)
                   .WillCascadeOnDelete(true)
                   ;
            }
        }
        #endregion /Configuration
        #region Properties
        public virtual TModalityQdtAction QdtAction { get; set; }
        public virtual TModalityQdtActor QdtActor { get; set; }
        public virtual TModalityQdtAllocationResource QdtAllocationResource { get; set; }
        public virtual TModalityQdtObject QdtObject { get; set; }
        public virtual TModalityQdtPosition QdtPosition { get; set; }
        public virtual TModalityQdtService QdtService { get; set; }
        //public virtual TModalityQdtConnection QdtConnection { get; set; }
        //public virtual TModalityQdtPrice QdtPrice { get; set; }
        //public virtual TModalityQdtRelation QdtRelation { get; set; }

        #endregion
        #region Constructors
        public BaseQdtQuiddity()
            : base()
        {

        }
        public BaseQdtQuiddity(long id, long cpKey)
            : base(id, cpKey)
        {

        }
        public BaseQdtQuiddity(_History history)
            : base(history)
        {

        }
        public BaseQdtQuiddity(long id, long cpKey, _History history)
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
