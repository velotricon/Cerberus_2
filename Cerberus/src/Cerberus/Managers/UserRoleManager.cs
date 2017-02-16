using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Interfaces.ManagerInterfaces;
using Cerberus.AbstractClasses;
using Cerberus.Models;

namespace Cerberus.Managers
{
    public class UserRoleManager : AbstractManager<USER_ROLE>, IUserRoleManager
    {
        public UserRoleManager(MainContext Context) : base(Context)
        {
        }

        public void AddUserRoles(int UserId, int[] RoleIds)
        {
            if(this.context.USER_ROLES.Any(x => x.USER_ID == UserId && RoleIds.Contains(x.ROLE_ID)))
            {
                throw new Exception("User already has given role!");
            }
            foreach(int id in RoleIds)
            {
                base.Add(new USER_ROLE()
                {
                    USER_ID = UserId,
                    ROLE_ID = id
                });
            }
        }

        public List<ROLE> GetUserRoles(int UserId)
        {
            return this.context.USER_ROLES.Where(x => x.USER_ID == UserId).Select(x => x.ROLE).ToList();
        }
    }
}
