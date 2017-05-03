using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class TRANSLATION
    {
        [Key]
        public int ID { get; set; }

        public string CODE { get; set; }
        public string LOCALE { get; set; }
        public string DESCRIPTION { get; set; }
        
        [ForeignKey("LOCALE")]
        public LOCALIZATION LOCALIZATION { get; set; }

        [ForeignKey("CODE")]
        public SYSTEM_CODE SYSTEM_CODE { get; set; }
    }
}
