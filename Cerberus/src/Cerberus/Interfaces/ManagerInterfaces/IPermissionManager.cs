using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface IPermissionManager
    {
        void AddNewPermission(PERMISSION NewPermission);
        List<PERMISSION> GetPermissions();
    }
}
