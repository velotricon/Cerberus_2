using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;
using Cerberus.AbstractClasses;

namespace Cerberus.Managers
{
    public class PermissionManager : AbstractManager, IPermissionManager
    {
        public PermissionManager(MainContext Context) : base(Context)
        {
        }

        public void AddNewPermission(PERMISSION NewPermission)
        {
            if (this.context.PERMISSIONS.Any(x => x.PREM_CODE == NewPermission.PREM_CODE))
            {
                throw new Exception("Permission with given code already exists in DB!");
            }
            else
            {
                this.context.PERMISSIONS.Add(NewPermission);
                this.context.SaveChanges();
            }
        }

        public List<PERMISSION> GetPermissions()
        {
            return this.context.PERMISSIONS.ToList();
        }
    }
}
