using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface IRoleManager : IAbstractManager<ROLE>
    {
        ROLE GetByName(string Name);
    }
}
