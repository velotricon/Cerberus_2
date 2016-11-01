﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public USER User { get; set; }
        public bool IsValid()
        {
            return this.Principal != null;
        }
    }
}
