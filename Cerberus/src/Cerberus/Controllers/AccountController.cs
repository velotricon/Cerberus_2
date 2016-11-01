using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cerberus.AbstractClasses;
using Cerberus.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cerberus.Controllers
{
    public class AccountController : AbstractController
    {
        public AccountController(MainContext Context) : base(Context)
        {
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel User)
        {
            throw new NotImplementedException();
        }
    }
}
