using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Containers
{
    public class GenericResultContainer
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
