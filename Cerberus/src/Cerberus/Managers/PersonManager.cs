using Cerberus.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;

namespace Cerberus.Managers
{
    public class PersonManager : AbstractManager<PERSON>, IPersonManager
    {
        public PersonManager(MainContext Context) : base(Context) { }

        public override void Add(PERSON NewPerson)
        {
            if (string.IsNullOrEmpty(NewPerson.NAME)) throw new Exception("Person name can not be null!");
            if (string.IsNullOrEmpty(NewPerson.SURNAME)) throw new Exception("Person surname can not be null!");

            base.Add(NewPerson);
        }
    }
}
