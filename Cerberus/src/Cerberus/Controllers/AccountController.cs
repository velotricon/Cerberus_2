using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cerberus.AbstractClasses;
using Cerberus.Models;
using Cerberus.Interfaces.ServiceInterfaces;
using Cerberus.Interfaces.ManagerInterfaces;
using Cerberus.Containers;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Cerberus.Utils;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cerberus.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : AbstractController
    {
        private readonly IMembershipService membership_service;
        private readonly IFileRepositoryService file_repository_service;
        private readonly IUserManager user_manager;
        private readonly IRoleManager role_manager;

        public AccountController(MainContext Context, 
            IMembershipService MembershipService, IFileRepositoryService FileRepositoryService,
            IUserManager UserManager, IRoleManager RoleManager) : base(Context)
        {
            this.membership_service = MembershipService;
            this.file_repository_service = FileRepositoryService;
            this.user_manager = UserManager;
            this.role_manager = RoleManager;
        }

        [Authorize]
        [HttpGet("GetAccountInfo")]
        public IActionResult GetAccountInfo()
        {
            GenericResultContainer profile_result = new GenericResultContainer();
            try
            {
                UserUtil user_util = new UserUtil(this.HttpContext);
                USER current_user = this.user_manager.GetComplete(user_util.GetCurrentUserId());
                ProfileViewModel profile_info = new ProfileViewModel()
                {
                    Username = current_user.LOGIN,
                    AvatarPath = current_user.AVATAR == null ? null : current_user.AVATAR.PATH,
                    Email = current_user.EMAIL
                };

                profile_result = new GenericResultContainer()
                {
                    Succeeded = true,
                    Message = null,
                    Result = profile_info
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
                return new ObjectResult(new GenericResultContainer()
                {
                    Succeeded = true
                });
            }
            catch(Exception ex)
            {
                return new ObjectResult(new GenericResultContainer()
                {
                    Succeeded = false,
                    Message = ex.Message
                });
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
                    claims.Add(new Claim(ClaimTypes.Name, user_context.User.LOGIN, ClaimValueTypes.String));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user_context.User.ID.ToString(), ClaimValueTypes.Integer32));

                    
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

        [Route("avatar")]
        [HttpPost]
        public IActionResult UploadAvatar()
        {
            GenericResultContainer result_container = new GenericResultContainer();

            try
            {
                IFormFile file = Request.Form.Files.First();
                UserUtil user_util = new UserUtil(this.HttpContext);
                int user_id = user_util.GetCurrentUserId();
                this.file_repository_service.AddUserAvatar(file, user_id);

                result_container.Succeeded = true;
            }
            catch(Exception ex)
            {
                result_container.Message = ex.Message;
                result_container.Succeeded = false;
            }

            return new ObjectResult(result_container);
        }

        [Route("avatar/delete")]
        [HttpPost]
        public IActionResult DeleteCurrentUserAvatar()
        {
            GenericResultContainer result_container = new GenericResultContainer();

            try
            {
                UserUtil user_util = new UserUtil(this.HttpContext);
                this.file_repository_service.RemoveUserAvatar(user_util.GetCurrentUserId());
                result_container.Succeeded = true;
            }
            catch(Exception ex)
            {
                result_container.Message = ex.Message;
                result_container.Succeeded = false;
            }

            return new ObjectResult(result_container);
        }
    }
}
