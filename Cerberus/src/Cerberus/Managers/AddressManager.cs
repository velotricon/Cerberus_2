using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.AbstractClasses;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;

namespace Cerberus.Managers
{
    public class AddressManager : AbstractManager<ADDRESS>, IAddressManager
    {
        public AddressManager(MainContext Context) : base(Context)
        {
        }
    }
}
