using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class EMPLOYEE
    {
        [Key]
        public int ID { get; set; }

        public bool IS_ACTIVE { get; set; }

        public int ROLE_ID { get; set; }
        public int PERSON_ID { get; set; }
        public int ADDRESS_ID { get; set; }
        public int BANK_ACCOUNT_ID { get; set; }

        [ForeignKey("ROLE_ID")]
        public ROLE ROLE { get; set; }

        [ForeignKey("PERSON_ID")]
        public PERSON PERSON { get; set; }

        [ForeignKey("ADDRESS_ID")]
        public ADDRESS ADDRESS { get; set; }

        [ForeignKey("BANK_ACCOUNT_ID")]
        public BANK_ACCOUNT BANK_ACCOUNT { get; set; }
    }
}
