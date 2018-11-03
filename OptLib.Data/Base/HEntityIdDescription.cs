using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.Base
{
    public abstract class HEntityIdDescription<TEntity>
        : EntityIdDescription<TEntity>
    {
        public HEntityIdDescription()
            : base()
        {

        }
        public HEntityIdDescription(TEntity id)
            : base(id)
        {

        }
        public HEntityIdDescription(TEntity id, int cid)
            : base(id)
        {
            this.History = new _History(cid);
        }

        /// <summary>
        /// اطلاعات اولیه تاریخچه تغییرات.
        /// </summary>
        /// <value>The history.</value>
        public _History History { get; set; } = new _History();
    }
}
