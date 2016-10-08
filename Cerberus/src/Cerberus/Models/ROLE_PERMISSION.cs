using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Models
{
    public class ROLE_PERMISSION
    {
        [Key]
        public int ID { get; set; }

        public int ROLE_ID { get; set; }
        public int PERMISSION_ID { get; set; }

        [ForeignKey("ROLE_ID")]
        public ROLE ROLE { get; set; }

        [ForeignKey("PERMISSION_ID")]
        public PERMISSION PERMISSION { get; set; }
    }
}
