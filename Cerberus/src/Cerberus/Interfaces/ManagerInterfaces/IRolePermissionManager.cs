using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface IRolePermissionManager
    {
        List<PERMISSION> GetRolePermissions(int RoleId);
        void AddPermissionToRole(int RoleId, int PermissionId);
        void RemovePermissionFromRole(int RoleId, int PermissionId);
    }
}
