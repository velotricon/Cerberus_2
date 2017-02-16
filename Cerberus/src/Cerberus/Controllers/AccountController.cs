using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cerberus.AbstractClasses;
using Cerberus.Models;
using Cerberus.Interfaces;
using Cerberus.Interfaces.ManagerInterfaces;
using Cerberus.Containers;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cerberus.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : AbstractController
    {
        private IMembershipService membership_service;
        private IUserManager user_manager;
        private IRoleManager role_manager;

        public AccountController(MainContext Context, IMembershipService MembershipService, 
            IUserManager UserManager, IRoleManager RoleManager) : base(Context)
        {
            this.membership_service = MembershipService;
            this.user_manager = UserManager;
            this.role_manager = RoleManager;
        }

        [HttpPost]
        public void Test()
        {

        }
        
        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel User)
        {
            IActionResult result = new ObjectResult(false);
            GenericResultContainer authentication_result = null;

            try
            {
                MembershipContext user_context = this.membership_service.ValidateUser(User.Username, User.Password);

                if(user_context.User != null)
                {
                    List<Claim> claims = new List<Claim>();
                    //this.membership_service.GetUserRoles();
                    claims.Add(new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String, User.Username)); //Tutaj trzeba by wyciągać uprawnienia z bazy

                    await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                        new AuthenticationProperties { IsPersistent = User.RememberMe });

                    authentication_result = new GenericResultContainer()
                    {
                        Succeeded = true,
                        Message = "Authentication succeeded"
                    };
                }
                else
                {
                    authentication_result = new GenericResultContainer()
                    {
                        Succeeded = false,
                        Message = "Authentication failed"
                    };
                }
            }
            catch(Exception ex)
            {
                authentication_result = new GenericResultContainer()
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }

            result = new ObjectResult(authentication_result);
            return result;
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegistrationViewModel User)
        {
            GenericResultContainer result_container = new GenericResultContainer();
            try
            {
                ROLE user_role = this.role_manager.GetByName("User");
                if (user_role == null) throw new Exception("No User role found!");
                USER new_user = membership_service.CreateUser(User.Login, User.Email, User.Password, new int[] { user_role.ID });
                if(new_user != null)
                {
                    result_container.Succeeded = true;
                    result_container.Message = "User created";
                }
                else
                {
                    result_container.Succeeded = false;
                    result_container.Message = "User not created";
                }
            }
            catch(Exception ex)
            {
                result_container.Succeeded = false;
                result_container.Message = ex.Message;
            }

            return new ObjectResult(result_container);
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
