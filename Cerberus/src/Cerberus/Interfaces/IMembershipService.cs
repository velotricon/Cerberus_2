using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;

namespace Cerberus.Interfaces
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string Username, string Password);
        USER CreateUser(string Username, string Email, string Password, int[] Roles);
        USER GetUser(int UserId);
        List<ROLE> GetUserRoles(string Username);
    }
}
