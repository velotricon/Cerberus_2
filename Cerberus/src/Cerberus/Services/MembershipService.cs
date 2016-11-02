using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Interfaces;
using Cerberus.Models;
using Cerberus.Interfaces.ManagerInterfaces;

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
            throw new NotImplementedException();
        }

        public List<ROLE> GetUserRoles(string Username)
        {
            throw new NotImplementedException();
        }

        public MembershipContext ValidateUser(string Username, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
