using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface IPersonManager
    {
        void AddPerson(PERSON NewPerson);
        void UpdatePerson(PERSON Person);
        List<PERSON> GetActivePersons();
        PERSON GetPerson(int PersonId);
        void DeactivatePerson(int PersonId);
    }
}
