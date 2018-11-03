using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRDc.Security
{
    public interface IOSecurity<TEsp>
    {
        bool Authentication { get; }
        string AtnHash { get; }
        int? _UserID { get; }
        //bool CheackPermission(ClsSPermission spr, List<ClsSPermission> lpermission = null);
        bool CheackPermission(TEsp pid);
    }
}
