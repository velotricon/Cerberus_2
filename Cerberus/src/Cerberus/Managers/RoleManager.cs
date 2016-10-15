using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Cerberus.AbstractClasses;
using Cerberus.Interfaces.ManagerInterfaces;

namespace Cerberus.Managers
{
    public class RoleManager : AbstractManager, IRoleManager
    {
        public RoleManager(MainContext Context) : base(Context) { }

        public List<ROLE> GetActiveRoles()
        {
            return this.context.ROLES.Where(x => x.IS_ACTIVE == true).ToList();
        }

        public void AddNewRole(ROLE NewRole)
        {
            if (string.IsNullOrEmpty(NewRole.ROLE_NAME)) throw new Exception("Role name can not be empty!");
            if (this.context.ROLES.Any(x => x.ROLE_NAME == NewRole.ROLE_NAME)) throw new Exception(NewRole.ROLE_NAME + " role already exists!");
            NewRole.IS_ACTIVE = true;
            this.context.ROLES.Add(NewRole);
            this.context.SaveChanges();
        }
    }
}
