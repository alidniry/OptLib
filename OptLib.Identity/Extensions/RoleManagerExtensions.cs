using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public static class RoleManagerExtensions
    {
        public static IdentityResult CreateRole<TRole, TKey>(this RoleManager<TRole, TKey> manager, TRole role)
            where TRole : class, IRole<TKey>
            where TKey : IEquatable<TKey>
        {
            if (!manager.RoleExists(role.Name))
                return manager.Create(role);
            return null;
        }
        public static void CreateRole<TRole, TKey>(this RoleManager<TRole, TKey> manager, params TRole[] role)
            where TRole : class, IRole<TKey>
            where TKey : IEquatable<TKey>
        {
            foreach (var item in role)
                manager.CreateRole(item);
        }

        public static IdentityResult DeleteRole<TRole, TKey>(this RoleManager<TRole, TKey> manager, TRole role)
            where TRole : class, IRole<TKey>
            where TKey : IEquatable<TKey>
        { return null; }
        public static TRole FindRoleById<TRole, TKey>(this RoleManager<TRole, TKey> manager, TKey roleId)
                where TRole : class, IRole<TKey>
                where TKey : IEquatable<TKey>
        { return null; }
        public static TRole FindRoleByName<TRole, TKey>(this RoleManager<TRole, TKey> manager, string roleName)
                    where TRole : class, IRole<TKey>
                    where TKey : IEquatable<TKey>
        { return null; }
        public static IdentityResult UpdateRole<TRole, TKey>(this RoleManager<TRole, TKey> manager, TRole role)
            where TRole : class, IRole<TKey>
            where TKey : IEquatable<TKey>
        { return null; }
    }
}
