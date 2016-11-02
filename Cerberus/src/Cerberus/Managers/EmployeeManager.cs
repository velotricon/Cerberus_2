using Cerberus.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;

namespace Cerberus.Managers
{
    public class EmployeeManager : AbstractManager<EMPLOYEE>, IEmployeeManager
    {
        public EmployeeManager(MainContext Context) : base(Context) { }
       
    }
}
