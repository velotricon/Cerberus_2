using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces
{
    public interface IEntityBasic
    {
        int ID { get; set; }
        bool IS_ACTIVE { get; set; }
    }
}
