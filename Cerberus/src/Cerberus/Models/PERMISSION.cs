using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Cerberus.Interfaces;

namespace Cerberus.Models
{
    public class PERMISSION : IEntityBasic
    {
        [Key]
        public int ID { get; set; }

        public bool IS_ACTIVE { get; set; }
        public string PREM_CODE { get; set; }
    }
}
