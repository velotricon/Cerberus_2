using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces
{
    public interface IContextUser
    {
        void Commit();
        void SetContext(MainContext Context);
        MainContext GetContext();
    }
}
