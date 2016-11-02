using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;
using Cerberus.AbstractClasses;

namespace Cerberus.Managers
{
    public class PermissionManager : AbstractManager<PERMISSION>, IPermissionManager
    {
        public PermissionManager(MainContext Context) : base(Context)
        {
        }
    }
}
