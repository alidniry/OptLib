using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.Base
{
    public abstract class HEntityIdName<TEntity>
        : EntityIdName<TEntity>
    {
        public HEntityIdName()
            : base()
        {

        }
        public HEntityIdName(string name)
            : base(name)
        {

        }
        public HEntityIdName(string name, int cid)
            : base(name)
        {
            this.History = new _History(cid);
        }
        public HEntityIdName(TEntity id, string name)
            : base(id, name)
        {

        }
        public HEntityIdName(TEntity id, string name, int cid)
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
