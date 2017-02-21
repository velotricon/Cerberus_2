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
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpGet]
        public IActionResult GetAccountInfo()
        {
            GenericResultContainer profile_result = new GenericResultContainer();
            try
            {
                profile_result = new GenericResultContainer()
                {
                    Succeeded = false,
                    Message = "Test"
                };
            }
            catch(Exception ex)
            {
                profile_result = new GenericResultContainer()
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }
            IActionResult result = new ObjectResult(profile_result);
            return result;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await this.HttpContext.Authentication.SignOutAsync("Cookies");
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
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
                    List<ROLE> roles = this.membership_service.GetUserRoles(User.Username);
                    foreach(ROLE role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.ROLE_NAME, ClaimValueTypes.String, User.Username));
                    }

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
    }
}
