using Cerberus.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;

namespace Cerberus.Managers
{
    public class PersonManager : AbstractManager
    {
        public void AddPerson(PERSON NewPerson)
        {
            if (string.IsNullOrEmpty(NewPerson.NAME)) throw new Exception("Person name can not be null!");
            if (string.IsNullOrEmpty(NewPerson.SURNAME)) throw new Exception("Person surname can not be null!");
            NewPerson.IS_ACTIVE = true;
            this.context.PERSONS.Add(NewPerson);
            this.context.SaveChanges();
            return;
        }

        public void UpdatePerson(PERSON Person)
        {
            Person.IS_ACTIVE = true;
            this.context.PERSONS.Update(Person);
            this.context.SaveChanges();
        }

        public List<PERSON> GetActivePersons()
        {
            return this.context.PERSONS.Where(x => x.IS_ACTIVE == true).ToList();
        }

        public PERSON GetPerson(int PersonId)
        {
            return this.context.PERSONS.Where(x => x.ID == PersonId).First();
        }

        public void DeactivatePerson(int PersonId)
        {
            PERSON person = this.context.PERSONS.Where(x => x.ID == PersonId).First();
            person.IS_ACTIVE = false;
            this.context.SaveChanges();
        }

        public PersonManager(MainContext Context) : base(Context) { }
    }
}
