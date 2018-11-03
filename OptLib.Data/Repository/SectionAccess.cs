using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Security
{
    public struct SectionAccess<esp>
    {
        public esp GetItem { get; set; }
        public esp GetList { get; set; }
        public esp Insert { get; set; }
        public esp Update { get; set; }
        public esp Delete { get; set; }
        public esp Del { get; set; }
        public esp Active { get; set; }
        public esp Block { get; set; }

        public SectionAccess(esp getItem, esp getList)
            : this()
        {
            GetItem = getItem;
            GetList = getList;
        }
        public SectionAccess(esp getItem, esp getList, esp insert, esp update, esp delet, esp del, esp active, esp block)
            : this()
        {
            GetItem = getItem;
            GetList = getList;
            Insert = insert;
            Update = update;
            Delete = delet;
            Del = del;
            Active = active;
            Block = block;
        }
    }
}
