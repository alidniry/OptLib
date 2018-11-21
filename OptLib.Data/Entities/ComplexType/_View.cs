using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.Data.ComplexType
{
    [ComplexType]
    public class _View
    {
        public _View()
        {

        }
        /// <summary>
        /// قابل نمایش بودن آیتم.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        //[Required]
        //virtual public bool Visible { get; set; } = true;

        /// <summary>
        /// پیش فرض
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public bool? Default { get; set; } = null;

        /// <summary>
        /// ترتیب نمایش
        /// </summary>
        /// <value>The view order.</value>
        public short? Order { get; set; } = null;

    }
}
