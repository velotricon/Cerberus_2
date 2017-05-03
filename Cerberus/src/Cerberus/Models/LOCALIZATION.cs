using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class LOCALIZATION
    {
        [Key]
        public string LOCALE { get; set; }
        public bool IS_ACTIVE { get; set; }
    }
}
