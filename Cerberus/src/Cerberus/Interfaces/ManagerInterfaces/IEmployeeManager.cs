﻿using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface IEmployeeManager
    {
        List<EMPLOYEE> GetActiveEmployees();
        void AddEmployee(EMPLOYEE NewEmployee);
    }
}
