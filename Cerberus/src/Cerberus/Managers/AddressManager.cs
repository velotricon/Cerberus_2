using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.AbstractClasses;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;

namespace Cerberus.Managers
{
    public class AddressManager : AbstractManager, IAddressManager
    {
        public AddressManager(MainContext Context) : base(Context)
        {
        }

        public void AddNewAddress(ADDRESS NewAddress)
        {
            NewAddress.IS_ACTIVE = true;
            this.context.ADDRESSES.Add(NewAddress);
            this.context.SaveChanges();
        }

        public List<ADDRESS> GetActiveAddresses()
        {
            return this.context.ADDRESSES.Where(x => x.IS_ACTIVE == true).ToList();
        }
    }
}
