using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptLib.Data.Base
{
    public abstract class HEntityIdValueNameDescription<TEntity>
        : EntityIdValueNameDescription<TEntity>
    {
        public HEntityIdValueNameDescription()
            : base()
        {
            SetValue(Id);
        }
        public HEntityIdValueNameDescription(string name)
            : base(name)
        {
            SetValue(Id);
        }
        public HEntityIdValueNameDescription(string name, int cid)
            : base(name)
        {
            SetValue(Id);
            this.History = new _History(cid);
        }
        public HEntityIdValueNameDescription(TEntity value, string name)
            : base(name)
        {
            SetValue(value);
        }
        public HEntityIdValueNameDescription(TEntity value, string name, int cid)
            : base(name)
        {
            SetValue(value);
            this.History = new _History(cid);
        }
        public HEntityIdValueNameDescription(TEntity id, TEntity value, string name)
            : base(id, name)
        {
            SetValue(value);
        }
        public HEntityIdValueNameDescription(TEntity id, TEntity value, string name, int cid)
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
