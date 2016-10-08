using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cerberus.Models
{
    public class PERMISSION
    {
        [Key]
        public int ID { get; set; }

        public string PREM_CODE { get; set; }
    }
}
