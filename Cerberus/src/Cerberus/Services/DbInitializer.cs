using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Cerberus.Managers;
using Cerberus.Interfaces;

namespace Cerberus.Services
{
    public class DbInitializer
    {
        private static MainContext context;
        private static IMembershipService membership_service;

        public static void Initialize(IServiceProvider AppServiceProvider)
        {
            context = (MainContext)AppServiceProvider.GetService(typeof(MainContext));
            membership_service = (IMembershipService)AppServiceProvider.GetService(typeof(IMembershipService));
            //InitializeSection
            InitUsersAndRoles();
            //end-of-InitializeSection
            context = null;
        }

        private static void InitUsersAndRoles()
        {
            PERMISSION super_user_perm;
            if (context.PERMISSIONS.Any(x => x.PREM_CODE == "SUPER_USER"))
            {
                super_user_perm = context.PERMISSIONS.First(x => x.PREM_CODE == "SUPER_USER");
            }
            else
            {
                super_user_perm = new PERMISSION() { PREM_CODE = "SUPER_USER" };
                context.PERMISSIONS.Add(super_user_perm);
            }
            super_user_perm.IS_ACTIVE = true;

            PERMISSION standard_user_perm;
            if (context.PERMISSIONS.Any(x => x.PREM_CODE == "USER"))
            {
                standard_user_perm = context.PERMISSIONS.First(x => x.PREM_CODE == "USER");
            }
            else
            {
                standard_user_perm = new PERMISSION() { PREM_CODE = "USER" };
                context.PERMISSIONS.Add(standard_user_perm);
            }
            standard_user_perm.IS_ACTIVE = true;

            ROLE super_user_role;
            if (context.ROLES.Any(x => x.ROLE_NAME == "SuperUser"))
            {
                super_user_role = context.ROLES.First(x => x.ROLE_NAME == "SuperUser");
            }
            else
            {
                super_user_role = new ROLE() { ROLE_NAME = "SuperUser" };
                context.ROLES.Add(super_user_role);
            }
            super_user_role.IS_ACTIVE = true;

            ROLE standard_user_role;
            if (context.ROLES.Any(x => x.ROLE_NAME == "User"))
            {
                standard_user_role = context.ROLES.First(x => x.ROLE_NAME == "User");
            }
            else
            {
                standard_user_role = new ROLE() { ROLE_NAME = "User" };
                context.ROLES.Add(standard_user_role);
            }
            standard_user_role.IS_ACTIVE = true;

            context.SaveChanges();

            ROLE_PERMISSION sup_rp;
            if (context.ROLE_PERMISSIONS.Any(x => x.PERMISSION_ID == super_user_perm.ID && x.ROLE_ID == super_user_role.ID))
            {
                sup_rp = context.ROLE_PERMISSIONS.First(x => x.PERMISSION_ID == super_user_perm.ID && x.ROLE_ID == super_user_role.ID);
            }
            else
            {
                sup_rp = new ROLE_PERMISSION() { ROLE = super_user_role, PERMISSION = super_user_perm };
                context.ROLE_PERMISSIONS.Add(sup_rp);
            }
            sup_rp.IS_ACTIVE = true;

            ROLE_PERMISSION std_rp;
            if (context.ROLE_PERMISSIONS.Any(x => x.PERMISSION_ID == standard_user_perm.ID && x.ROLE_ID == standard_user_role.ID))
            {
                std_rp = context.ROLE_PERMISSIONS.First(x => x.PERMISSION_ID == standard_user_perm.ID && x.ROLE_ID == standard_user_role.ID);
            }
            else
            {
                std_rp = new ROLE_PERMISSION() { ROLE = standard_user_role, PERMISSION = standard_user_perm };
                context.ROLE_PERMISSIONS.Add(std_rp);
            }
            std_rp.IS_ACTIVE = true;


            USER super_user;
            if (context.USERS.Any(x => x.EMAIL == "superuser@cerberus.com" && x.LOGIN == "superuser"))
            {
                super_user = context.USERS.First(x => x.EMAIL == "superuser@cerberus.com" && x.LOGIN == "superuser");
            }
            else
            {
                //super_user = new USER() { EMAIL = "superuser@cerberus.com", LOGIN = "superuser", PASSWORD = "qw12qwas", 
                //CREATE_DATE = DateTime.Now/*ROLE_ID = super_user_role.ID*/ };
                //context.USERS.Add(super_user);
                super_user = membership_service.CreateUser("superuser", "superuser@cerberus.com", "qw12qwas", new int[] { super_user_role.ID });
            }
            super_user.IS_ACTIVE = true;

            USER standard_user;
            if (context.USERS.Any(x => x.EMAIL == "user@cerberus.com" && x.LOGIN == "user"))
            {
                standard_user = context.USERS.First(x => x.EMAIL == "user@cerberus.com" && x.LOGIN == "user");
            }
            else
            {
                //standard_user = new USER() { EMAIL = "user@cerberus.com", LOGIN = "user", PASSWORD = "qw12qwas",
                //    CREATE_DATE = DateTime.Now/*ROLE_ID = standard_user_role.ID*/
                //};
                //context.USERS.Add(standard_user);
                standard_user = membership_service.CreateUser("user", "user@cerberus.com", "qw12qwas", new int[] { standard_user_role.ID });
            }
            standard_user.IS_ACTIVE = true;

            context.SaveChanges(); //SAVE CHANGES

            USER_ROLE user_role_super_user = null;
            if (context.USER_ROLES.Any(x => x.USER_ID == super_user.ID && x.ROLE_ID == super_user_role.ID))
            {
                user_role_super_user = context.USER_ROLES.First(x => x.USER_ID == super_user.ID && x.ROLE_ID == super_user_role.ID);
            }
            else
            {
                user_role_super_user = new USER_ROLE()
                {
                    ROLE = super_user_role,
                    USER = super_user
                };
                context.USER_ROLES.Add(user_role_super_user);
            }
            user_role_super_user.IS_ACTIVE = true;
            
            USER_ROLE user_role_standard_user = null;
            if(context.USER_ROLES.Any(x => x.USER_ID == standard_user.ID && x.ROLE_ID == standard_user_role.ID))
            {
                user_role_standard_user = context.USER_ROLES.First(x => x.USER_ID == standard_user.ID && x.ROLE_ID == standard_user_role.ID);
            }
            else
            {
                user_role_standard_user = new USER_ROLE()
                {
                    ROLE = standard_user_role,
                    USER = standard_user
                };
                context.USER_ROLES.Add(user_role_standard_user);
            }
            user_role_standard_user.IS_ACTIVE = true;

            context.SaveChanges(); //SAVE CHANGES
        }
    }
}
