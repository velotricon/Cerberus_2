using Cerberus.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class ROLE : IEntityBasic
    {
        [Key]
        public int ID { get; set; }

        public bool IS_ACTIVE { get; set; }

        public string ROLE_NAME { get; set; }
    }
}
