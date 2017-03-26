using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Interfaces.ServiceInterfaces;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;
using System.Security.Principal;

namespace Cerberus.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUserManager user_manager;
        private readonly IRoleManager role_manager;
        private readonly IUserRoleManager user_role_manager;
        private readonly IEncryptionService encryption_service;

        public MembershipService(IUserManager UserManager, IRoleManager RoleManager,
            IUserRoleManager UserRoleManager, IEncryptionService EncryptionService)
        {
            this.user_manager = UserManager;
            this.role_manager = RoleManager;
            this.user_role_manager = UserRoleManager;
            this.encryption_service = EncryptionService;
        }

        public USER CreateUser(string Username, string Email, string Password, int[] Roles)
        {
            if (this.user_manager.UserExists(Username)) throw new Exception("User " + Username + " already exists!");
            string password_salt = this.encryption_service.CreateSalt();
            string hashed_password = this.encryption_service.EncryptPassword(Password, password_salt);
            USER new_user = new USER()
            {
                LOGIN = Username,
                EMAIL = Email,
                IS_ACTIVE = true,
                PASSWORD = hashed_password,
                SALT = password_salt,
                CREATE_DATE = DateTime.Now
            };

            TransactionContext transaction_context = new TransactionContext();
            transaction_context.AddContextUser(user_manager);
            transaction_context.AddContextUser(user_role_manager);
            transaction_context.BeginTransaction();
            try
            {
                this.user_manager.Add(new_user);
                this.user_manager.Commit();
                this.user_role_manager.AddUserRoles(new_user.ID, Roles);
                //Stuff here
                transaction_context.CommtTransaction();
            }
            catch(Exception ex)
            {
                transaction_context.RollbackTransaction();
                throw ex;
            }
            return new_user;
        }

        public USER GetUser(int UserId)
        {
            USER user = this.user_manager.Get(UserId);
            if (user != null)
                return user;
            else
                throw new Exception("User does not exist.");
        }

        public List<ROLE> GetUserRoles(string Username)
        {
            USER user = this.user_manager.GetByName(Username);
            return this.user_role_manager.GetUserRoles(user.ID);
        }

        public MembershipContext ValidateUser(string Username, string Password)
        {
            MembershipContext membership_context = new MembershipContext();
            if(this.IsUserValid(Username, Password))
            {
                membership_context.User = this.user_manager.GetByName(Username);
                GenericIdentity identity = new GenericIdentity(Username);
                membership_context.Principal = new GenericPrincipal(
                    identity,
                    this.GetUserRoles(Username).Select(x => x.ROLE_NAME).ToArray()
                    );
            }
            return membership_context;
        }

        private bool IsUserValid(string Username, string Password)
        {
            if (this.user_manager.UserExists(Username))
            {
                USER user = this.user_manager.GetByName(Username);
                if (user.PASSWORD == this.encryption_service.EncryptPassword(Password, user.SALT))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
