using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.AbstractClasses;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;

namespace Cerberus.Managers
{
    public class RolePermissionManager : AbstractManager<ROLE_PERMISSION>, IRolePermissionManager
    {
        public RolePermissionManager(MainContext Context) : base(Context)
        {
        }

        public void AddPermissionToRole(int RoleId, int PermissionId)
        {
            if (this.context.ROLE_PERMISSIONS.Any(x => x.ROLE_ID == RoleId && x.PERMISSION_ID == PermissionId))
            {
                throw new Exception("This role already have given permission");
            }

            ROLE_PERMISSION new_role_perm = new ROLE_PERMISSION();
            new_role_perm.ROLE_ID = RoleId;
            new_role_perm.PERMISSION_ID = PermissionId;

            base.Add(new_role_perm);
        }

        public List<PERMISSION> GetRolePermissions(int RoleId)
        {
            var result = from roleperm in this.context.ROLE_PERMISSIONS
                         from perm in this.context.PERMISSIONS
                         where roleperm.ROLE_ID == RoleId
                         & roleperm.PERMISSION_ID == perm.ID
                         select perm;
            List<PERMISSION> permissions = result.ToList();
            return permissions;
        }

        public void RemovePermissionFromRole(int RoleId, int PermissionId)
        {
            this.context.ROLE_PERMISSIONS.RemoveRange(this.context.ROLE_PERMISSIONS.Where(x => x.ROLE_ID == RoleId && x.PERMISSION_ID == PermissionId));
        }
    }
}
