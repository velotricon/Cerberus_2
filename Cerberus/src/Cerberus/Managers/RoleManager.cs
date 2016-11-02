using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Cerberus.AbstractClasses;
using Cerberus.Interfaces.ManagerInterfaces;

namespace Cerberus.Managers
{
    public class RoleManager : AbstractManager<ROLE>, IRoleManager
    {
        public RoleManager(MainContext Context) : base(Context) { }

        public override void Add(ROLE NewRole)
        {
            if (string.IsNullOrEmpty(NewRole.ROLE_NAME)) throw new Exception("Role name can not be empty!");
            if (this.context.ROLES.Any(x => x.ROLE_NAME == NewRole.ROLE_NAME)) throw new Exception(NewRole.ROLE_NAME + " role already exists!");

            base.Add(NewRole);
        }

        public ROLE GetByName(string Name)
        {
            return this.context.ROLES.Where(x => x.ROLE_NAME == Name && x.IS_ACTIVE == true).First();
        }
    }
}
