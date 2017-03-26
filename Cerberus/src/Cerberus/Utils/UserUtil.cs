using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cerberus.Utils
{
    public class UserUtil
    {
        private HttpContext http_context;
        public UserUtil(HttpContext CurrentContext)
        {
            this.http_context = CurrentContext;
        }

        public int GetCurrentUserId()
        {
            Claim id_claim = this.http_context.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            int user_id = int.Parse(id_claim.Value);
            return user_id;
        }

        public string GetCurrentUserName()
        {
            Claim name_claim = this.http_context.User.Claims.First(x => x.Type == ClaimTypes.Name);
            return name_claim.Value;
        }
    }
}
