using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRDc.Security
{
    public class Sec : IOSecurity1
    {
        public bool Authentication => throw new NotImplementedException();

        public string AtnHash => throw new NotImplementedException();

        public int? _UserID => throw new NotImplementedException();

        public bool CheackPermission(int pid)
        {
            throw new NotImplementedException();
        }
    }
    public interface IOSecurity1
    {
        bool Authentication { get; }
        string AtnHash { get; }
        int? _UserID { get; }
        //bool CheackPermission(ClsSPermission spr, List<ClsSPermission> lpermission = null);
        bool CheackPermission(int pid);
    }
    abstract public class bSecurity
    {
        abstract public bool Authentication { get; }
        public int? _UserID { get; protected set; }
    }
    //public class ClsSecurity
    //{
    //    public List<ClsGroup> Groups = new List<ClsGroup>();
    //    public List<string> Permissions = new List<string>();
    //    public List<string> PermissionTables = new List<string>();

    //    public ClsSecurity()
    //    {

    //    }
    //    public ClsSecurity(string user, string password)
    //    {
    //        SetValue(user, password);
    //    }
    //    public void SetValue(string user, string password)
    //    {
    //        UserName = user;
    //        PasswordHash = ClsExtendedLibrary.GetMD5Hash(password);
    //    }
    //    public string UserName { get; set; }
    //    public string PasswordHash { get; set; }

    //}
    //public class ClsGroup : IEquatable<ClsGroup>
    //{
    //    public ClsGroup(int id, string name)
    //    {
    //        ID = id;
    //        Name = name;
    //    }
    //    public int ID { get; set; }
    //    public string Name { get; set; }

    //    public override string ToString()
    //    {
    //        return "ID: " + ID + "   Name: " + Name;
    //    }
    //    public override bool Equals(object obj)
    //    {
    //        if (obj == null) return false;
    //        ClsGroup objAsGroup = obj as ClsGroup;
    //        if (objAsGroup == null) return false;
    //        else return Equals(objAsGroup);
    //    }
    //    public bool Equals(ClsGroup other)
    //    {
    //        if (other == null) return false;
    //        return (this.ID.Equals(other.ID));
    //    }
    //    public override int GetHashCode()
    //    {
    //        return ID;
    //    }
    //    // Should also override == and != operators.
    //}
}
