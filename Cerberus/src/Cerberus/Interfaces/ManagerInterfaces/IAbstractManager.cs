using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface IAbstractManager<T> where T : class, IEntityBasic, new ()
    {
        void Commit();
        MainContext GetContext();
        void SetContext(MainContext Context);
        T Get(int Id);
        void Add(T Entity);
        void Update(T Entity);
        void Disable(int Id);
        void Delete(int Id);
        IEnumerable<T> GetAllActive();
    }
}
