using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class ADDRESS
    {
        [Key]
        public int ID { get; set; }

        public bool IS_ACTIVE { get; set; }

        public string COUNTRY_CODE { get; set; }
        public string CITY { get; set; }
        public string ZIP_CODE { get; set; }
        public string STREET { get; set; }
        public string HOUSE_NUMBER { get; set; }
    }
}
