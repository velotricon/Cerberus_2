using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class SYSTEM_CODE
    {
        [Key]
        public string CODE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
