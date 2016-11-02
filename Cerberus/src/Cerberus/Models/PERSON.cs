using Cerberus.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class PERSON : IEntityBasic
    {
        [Key]
        public int ID { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
    }
}
