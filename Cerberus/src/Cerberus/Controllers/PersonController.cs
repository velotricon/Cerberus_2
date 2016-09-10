using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cerberus.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cerberus.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<PersonViewModel> Get()
        {
            List<PersonViewModel> person_list = new List<PersonViewModel>();
            person_list.Add(new PersonViewModel() { Id = 1, Name = "Jan", Surname = "Kowalski" });
            person_list.Add(new PersonViewModel() { Id = 2, Name = "Janusz", Surname = "Tracz" });
            string tmp = JsonConvert.SerializeObject(person_list);
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
        public void Post([FromBody]string value)
        {
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
