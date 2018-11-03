using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.Data.ComplexType
{
    /// <summary>
    /// کلاس افزایشی تاریخچه تغییرات
    /// </summary>
    [ComplexType]
    public class _HistoryLog
    {
        public _HistoryLog()
            : this(1)
        {

        }
        public _HistoryLog(int actorId)
        {
            this.SetValue(actorId);
        }
        public _HistoryLog(int actorId, eHistoryLog activety)
        {
            this.SetValue(actorId, activety);
        }

        /// <summary>
        /// کد کاربر ایجاد کننده.
        /// </summary>
        /// <value>The create unique identifier.</value>
        [Required]
        public int ActorID { get; set; } = 1;
        /// <summary>
        /// فعالیت انجام گرفته
        /// </summary>
        /// <value>The activety.</value>
        [Required]
        public eHistoryLog Activety { get; set; } = eHistoryLog.CHANGE;
        /// <summary>
        /// زمان ایجاد اطلاعات.
        /// </summary>
        /// <value>The create time.</value>
        [Required]
        public DateTime Date { get; set; }

        public virtual void SetValue(int actorId)
        {
            this.SetValue(actorId, eHistoryLog.CHANGE);
        }
        public virtual void SetValue(int actorId, eHistoryLog activety)
        {
            this.ActorID = actorId;
            this.Activety = activety;
            this.Date = DateTime.Now;
        }

    }
}
