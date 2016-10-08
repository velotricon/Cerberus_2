using System;
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
            //PERMISSION super_user_perm = new PERMISSION() { PREM_CODE = "SUPER_USER" };
            //PERMISSION standard_user_perm = new PERMISSION() { PREM_CODE = "USER" };
            //context.PERMISSIONS.Add(super_user_perm);
            //context.PERMISSIONS.Add(standard_user_perm);
            
            //ROLE super_user_role = new ROLE() { ROLE_NAME = "SuperUser" };
            //ROLE standard_user_role = new ROLE() { ROLE_NAME = "User" };
            //context.ROLES.Add(super_user_role);
            //context.ROLES.Add(standard_user_role);

            //ROLE_PERMISSION sup_rp = new ROLE_PERMISSION() { ROLE = super_user_role, PERMISSION = super_user_perm };
            //ROLE_PERMISSION std_rp = new ROLE_PERMISSION() { ROLE = standard_user_role, PERMISSION = standard_user_perm };
            //context.Add(sup_rp);
            //context.Add(std_rp);

            //context.SaveChanges();

            ////ROLE_PERMISSION super_rp = new ROLE_PERMISSION() { PERMISSION_ID = super_user_perm.ID, ROLE_ID = super_user_role.ID };
            ////ROLE_PERMISSION standard_rp = new ROLE_PERMISSION() { PERMISSION_ID = standard_user_perm.ID, ROLE_ID = standard_user_role.ID };

            //USER super_user = new USER() { EMAIL = "superuser@cerberus.com" };
            //USER standard_user = new USER() { EMAIL = "user@cerberus.com" };
        }
    }
}
