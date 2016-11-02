using Cerberus.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class USER_ROLE : IEntityBasic
    {
        [Key]
        public int ID { get; set; }

        public bool IS_ACTIVE { get; set; }
        public int USER_ID { get; set; }
        public int ROLE_ID { get; set; }

        [ForeignKey("USER_ID")]
        public USER USER { get; set; }

        [ForeignKey("ROLE_ID")]
        public ROLE ROLE { get; set; }
    }
}
