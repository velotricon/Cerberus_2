using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Interfaces.ManagerInterfaces;
using Cerberus.Models;
using Cerberus.AbstractClasses;
using Microsoft.EntityFrameworkCore;

namespace Cerberus.Managers
{
    public class UserManager : AbstractManager<USER>, IUserManager
    {
        public UserManager(MainContext Context) : base(Context) { }

        public override void Add(USER NewUser)
        {
            if (this.context.USERS.Any(x => x.LOGIN == NewUser.LOGIN)) throw new Exception("User " + NewUser.LOGIN + " already exists!");
            if (this.context.USERS.Any(x => x.EMAIL == NewUser.EMAIL)) throw new Exception("This email is already in use!");

            base.Add(NewUser);
        }

        public bool UserExists(string UserName)
        {
            return this.context.USERS.Any(x => x.IS_ACTIVE == true && x.LOGIN == UserName);
        }

        public USER GetByName(string UserName)
        {
            USER user = this.context.USERS.Where(x => x.LOGIN == UserName).First();
            if (user != null)
                return user;
            else
                throw new Exception("User with given name does not exist.");
        }

        public USER GetComplete(int Id)
        {
            USER result = this.context.USERS.Where(x => x.ID == Id && x.IS_ACTIVE == true).Include(x => x.AVATAR).First();
            return result;
        }
    }
}
