using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cerberus.Models;
using Newtonsoft.Json;
using Cerberus.Managers;
using Cerberus.AbstractClasses;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cerberus.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : AbstractController
    {
        //Skoro MainContext jest wstrzykiwany do kontrolera to może jakoś dało by się zrobić tak,
        //żeby wstrzykiwany był też odpowiedni manager (w tym przypadku PersonManager)?

        public PersonController(MainContext Context) : base(Context)
        {
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<PERSON> Get()
        {
            PersonManager manager = new PersonManager(this.context);
            IEnumerable<PERSON> person_list = manager.GetAllActive();
            return person_list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public int Post([FromBody]PERSON value)
        {
            PersonManager manager = new PersonManager(this.context);
            manager.Add(value);
            return value.ID;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
    }
}
