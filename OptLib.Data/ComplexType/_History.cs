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
    /// کلاس افزایشی فاعلیتها
    /// </summary>
    /// <seealso cref="OptLib.Data.Base._IHistory" />
    [ComplexType]
    public class _History 
    {
        public _History()
        {
            SetValue(1);
        }
        public _History(bool unchangeable, bool nonremovable)
        {
            SetValue(1, unchangeable, nonremovable);
        }
        public _History(int cid)
        {
            SetValue(cid);
        }
        public _History(int cid, bool unchangeable, bool nonremovable)
        {
            SetValue(cid, unchangeable, nonremovable);
        }

        /// <summary>
        /// کد کاربر ایجاد کننده.
        /// </summary>
        /// <value>The create unique identifier.</value>
        [Required]
        public int CreateID { get; set; }
        /// <summary>
        /// زمان ایجاد اطلاعات.
        /// </summary>
        /// <value>The create time.</value>
        [Required]
        public DateTime CreateDate { get; set; }

        //Last Changes
        /// <summary>
        /// کد آخرین کاربر تغییر دهنده اطلاعات.
        /// </summary>
        /// <value>The history last changes identifier.</value>
        [Required]
        public int LastChangesID { get; set; }
        /// <summary>
        /// زمان آخرین تغییر اطلاعات.
        /// </summary>
        /// <value>The history last changes time.</value>
        [Required]
        public DateTime LastChangesDate { get; set; }

        /// <summary>
        /// خذف آیتم.
        /// </summary>
        /// <value><c>true</c> if delete; otherwise, <c>false</c>.</value>
        [Required]
        public bool DEL { get; set; }
        /// <summary>
        /// کد کاربر حذف کننده اطلاعات.
        /// </summary>
        /// <value>The delete unique identifier.</value>
        public int? DeleteID { get; set; }
        /// <summary>
        /// زمان خذف اطلاعات.
        /// </summary>
        /// <value>The delete time.</value>
        public DateTime? DeleteDate { get; set; }

        /// <summary>
        /// غیر قابل تغییر
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [Required]
        virtual public bool UnChangeable { get; set; } = false;
        /// <summary>
        /// غیر قابل حذف
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [Required]
        virtual public bool NonRemovable { get; set; } = false;

        virtual public void SetValue(int cid)
        {
            SetCreator(cid);
            SetLastModifier(cid);
            this.DEL = false;
        }
        virtual public void SetValue(int cid, bool unchangeable, bool nonremovable)
        {
            SetCreator(cid);
            SetLastModifier(cid);
            this.DEL = false;
            this.UnChangeable = unchangeable;
            this.NonRemovable = nonremovable;
        }

        /// <summary>
        /// اعلام خالق
        /// </summary>
        /// <param name="id">The identifier.</param>
        virtual public void SetCreator(int id)
        {
            CreateID = id;
            CreateDate = DateTime.Now;
        }
        /// <summary>
        /// اعلام حذف کننده
        /// </summary>
        /// <param name="id">The identifier.</param>
        virtual public void SetDetergent(int id)
        {
            DEL = true;
            DeleteID = id;
            DeleteDate = DateTime.Now;
        }
        /// <summary>
        /// اعلام آخرین تغییر دهنده
        /// </summary>
        /// <param name="id">The identifier.</param>
        virtual public void SetLastModifier(int id)
        {
            LastChangesID = id;
            LastChangesDate = DateTime.Now;
        }

    }
}
