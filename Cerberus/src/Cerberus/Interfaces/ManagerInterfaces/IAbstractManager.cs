﻿using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface IAbstractManager<T> : IContextUser where T : class, IEntityBasic, new ()
    {
        T Get(int Id);
        void Add(T Entity);
        void Update(T Entity);
        void Disable(int Id);
        void Delete(int Id);
        IEnumerable<T> GetAllActive();
    }
}
