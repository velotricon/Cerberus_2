using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface IUserManager : IAbstractManager<USER>
    {
        bool UserExists(string UserName);
        USER GetByName(string UserName);
        USER GetComplete(int Id);
    }
}
