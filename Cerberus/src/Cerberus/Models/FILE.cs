using Cerberus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class FILE : IEntityBasic
    {
        public int ID { get; set; }
        public bool IS_ACTIVE { get; set; }

        public string FULL_NAME { get; set; }
        public string NAME { get; set; }
        public string CONTENT_TYPE { get; set; }
        public string PATH { get; set; }
    }
}
