﻿using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface IUserManager
    {
        bool UserExists(string UserName);
        void AddUser(USER NewUser);
    }
}
