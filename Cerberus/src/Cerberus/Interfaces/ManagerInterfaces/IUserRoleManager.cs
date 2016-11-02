using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface IUserRoleManager : IAbstractManager<USER_ROLE>
    {
        void AddUserRoles(int UserId, int[] RoleIds);
    }
}
