using Cerberus.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;

namespace Cerberus.Managers
{
    public class EmployeeManager : AbstractManager, IEmployeeManager
    {
        public EmployeeManager(MainContext Context) : base(Context) { }

        public List<EMPLOYEE> GetActiveEmployees()
        {
            return this.context.EMPLOYEES.Where(x => x.IS_ACTIVE == true).ToList();
        }

        public void AddEmployee(EMPLOYEE NewEmployee)
        {
            NewEmployee.IS_ACTIVE = true;
            this.context.EMPLOYEES.Add(NewEmployee);
            this.context.SaveChanges();
        }
    }
}
