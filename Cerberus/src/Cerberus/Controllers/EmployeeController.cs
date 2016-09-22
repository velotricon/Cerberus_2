using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cerberus.AbstractClasses;
using Cerberus.Models;
using Cerberus.Managers;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cerberus.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : AbstractController
    {
        public EmployeeController(MainContext Context) : base(Context) { }


        // GET: api/values
        [HttpGet]
        public IEnumerable<EMPLOYEE> Get()
        {
            EmployeeManager manager = new EmployeeManager(this.context);
            return manager.GetActiveEmployees();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public int Post([FromBody]EMPLOYEE value)
        {
            EmployeeManager manager = new EmployeeManager(this.context);
            manager.AddEmployee(value);
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
