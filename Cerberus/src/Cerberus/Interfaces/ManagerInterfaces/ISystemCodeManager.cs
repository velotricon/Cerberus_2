using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface ISystemCodeManager
    {
        SYSTEM_CODE Get(string Code);
        void Add(SYSTEM_CODE Entity);
        void Update(SYSTEM_CODE Entity);
        void Disable(string Code);
        void Delete(string Code);
        IEnumerable<SYSTEM_CODE> GetAllActive();
    }
}
