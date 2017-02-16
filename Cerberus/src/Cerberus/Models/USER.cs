using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cerberus.Interfaces;

namespace Cerberus.Models
{
    public class USER : IEntityBasic
    {
        [Key]
        public int ID { get; set; }

        public bool IS_ACTIVE { get; set; }
        public string EMAIL { get; set; }
        public string LOGIN { get; set; }
        public string PASSWORD { get; set; }
        public string SALT { get; set; }
        public DateTime CREATE_DATE { get; set; }

        //public int ROLE_ID { get; set; }
        //
        //[ForeignKey("ROLE_ID")]
        //public ROLE ROLE { get; set; }
    }
}
