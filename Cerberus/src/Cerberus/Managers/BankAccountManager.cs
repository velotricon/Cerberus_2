﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.AbstractClasses;
using Cerberus.Models;

namespace Cerberus.Managers
{
    public class BankAccountManager : AbstractManager
    {
        public BankAccountManager(MainContext Context) : base(Context)
        {
        }

        public void AddNewBankAccount(BANK_ACCOUNT NewAccount)
        {
            
        }
    }
}
