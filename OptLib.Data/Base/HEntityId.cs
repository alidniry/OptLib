using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OptLib.Data.Base
{
    public abstract class HEntityId<TEntity>
        : EntityId<TEntity>
    {
        public HEntityId()
            : base()
        {

        }
        public HEntityId(int cid)
            : base()
        {
            this.History = new _History(cid);
        }
        public HEntityId(TEntity id, int cid)
            : base(id)
        {
            this.History = new _History(cid);
        }

        /// <summary>
        /// اطلاعات اولیه تاریخچه تغییرات.
        /// </summary>
        /// <value>The history.</value>
        [Required]
        public _History History { get; set; } = new _History();
    }
}
