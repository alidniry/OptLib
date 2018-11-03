using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.Base
{
    public abstract class HEntityIdNameDescription<TEntity>
        : EntityIdNameDescription<TEntity>
    {
        public HEntityIdNameDescription()
            : base()
        {

        }
        public HEntityIdNameDescription(string name)
            : base(name)
        {

        }
        public HEntityIdNameDescription(string name, int cid)
            : base(name)
        {
            this.History = new _History(cid);
        }
        public HEntityIdNameDescription(TEntity id, string name)
            : base(id, name)
        {

        }
        public HEntityIdNameDescription(TEntity id, string name, int cid)
            : base(id, name)
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
