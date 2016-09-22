using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class BANK_ACCOUNT
    {
        [Key]
        public int ID { get; set; }

        public bool IS_ACTIVE { get; set; }

        public string BANK_NAME { get; set; }
        public string ACCOUNT_NUMBER { get; set; }
        public string IBAN { get; set; }
        public string SWIFT_CODE { get; set; }

        public int ADDRESS_ID { get; set; }

        [ForeignKey("ADDRESS_ID")]
        public ADDRESS ADDRESS { get; set; }
    }
}
