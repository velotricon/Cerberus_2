﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Cerberus.Managers;

namespace Cerberus.Services
{
    public class DbInitializer
    {
        private static MainContext context;

        public static void Initialize(IServiceProvider AppServiceProvider)
        {
            context = (MainContext)AppServiceProvider.GetService(typeof(MainContext));
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

            context.SaveChanges();

            ROLE_PERMISSION sup_rp;
            if (context.ROLE_PERMISSIONS.Any(x => x.PERMISSION_ID == super_user_perm.ID && x.ROLE_ID == super_user_role.ID))
            {
                sup_rp = context.ROLE_PERMISSIONS.First(x => x.PERMISSION_ID == super_user_perm.ID && x.ROLE_ID == super_user_role.ID);
            }
            else
            {
                sup_rp = new ROLE_PERMISSION() { ROLE = super_user_role, PERMISSION = super_user_perm };
                context.Add(sup_rp);
            }

            ROLE_PERMISSION std_rp;
            if (context.ROLE_PERMISSIONS.Any(x => x.PERMISSION_ID == standard_user_perm.ID && x.ROLE_ID == standard_user_role.ID))
            {
                std_rp = context.ROLE_PERMISSIONS.First(x => x.PERMISSION_ID == standard_user_perm.ID && x.ROLE_ID == standard_user_role.ID);
            }
            else
            {
                std_rp = new ROLE_PERMISSION() { ROLE = standard_user_role, PERMISSION = standard_user_perm };
                context.Add(std_rp);
            }


            USER super_user;
            if (context.USERS.Any(x => x.EMAIL == "superuser@cerberus.com" && x.LOGIN == "superuser"))
            {
                super_user = context.USERS.First(x => x.EMAIL == "superuser@cerberus.com" && x.LOGIN == "superuser");
            }
            else
            {
                super_user = new USER() { EMAIL = "superuser@cerberus.com", LOGIN = "superuser", PASSWORD = "qw12qwas", ROLE_ID = super_user_role.ID };
                context.Add(super_user);
            }

            USER standard_user;
            if (context.USERS.Any(x => x.EMAIL == "user@cerberus.com" && x.LOGIN == "user"))
            {
                standard_user = context.USERS.First(x => x.EMAIL == "user@cerberus.com" && x.LOGIN == "user");
            }
            else
            {
                standard_user = new USER() { EMAIL = "user@cerberus.com", LOGIN = "user", PASSWORD = "qw12qwas", ROLE_ID = standard_user_role.ID };
                context.Add(standard_user);
            }

            context.SaveChanges();
        }
    }
}
