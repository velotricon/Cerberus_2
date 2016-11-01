using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Interfaces.ManagerInterfaces;
using Cerberus.Models;
using Cerberus.AbstractClasses;

namespace Cerberus.Managers
{
    public class UserManager : AbstractManager, IUserManager
    {
        public UserManager(MainContext Context) : base(Context) { }

        public void AddUser(USER NewUser)
        {
            if (this.context.USERS.Any(x => x.LOGIN == NewUser.LOGIN)) throw new Exception("User " + NewUser.LOGIN + " already exists!");
            if (this.context.USERS.Any(x => x.EMAIL == NewUser.EMAIL)) throw new Exception("This email is already in use!");

            NewUser.IS_ACTIVE = true;
            this.context.USERS.Add(NewUser);
            this.save_changes();
        }

        public bool UserExists(string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
