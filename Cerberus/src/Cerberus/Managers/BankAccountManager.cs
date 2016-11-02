using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.AbstractClasses;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;

namespace Cerberus.Managers
{
    public class BankAccountManager : AbstractManager<BANK_ACCOUNT>, IBankAccountManager
    {
        public BankAccountManager(MainContext Context) : base(Context)
        {
        }
    }
}
