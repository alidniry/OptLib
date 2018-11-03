using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.Base
{
    public abstract class HEntityIdValueName<TEntity>
        : EntityIdValueName<TEntity>
    {
        public HEntityIdValueName()
            : base()
        {
            SetValue(Id);
        }
        public HEntityIdValueName(string name, int cid)
            : base(name)
        {
            SetValue(Id);
            this.History = new _History(cid);
        }
        public HEntityIdValueName(TEntity value, string name, int cid)
            : base(name)
        {
            SetValue(value);
            this.History = new _History(cid);
        }
        public HEntityIdValueName(TEntity id, TEntity value, string name, int cid = 1)
            : base(id, name)
        {
            SetValue(value);
            this.History = new _History(cid);
        }

        /// <summary>
        /// اطلاعات اولیه تاریخچه تغییرات.
        /// </summary>
        /// <value>The history.</value>
        public _History History { get; set; } = new _History();
    }
}
