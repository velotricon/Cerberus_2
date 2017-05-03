using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ManagerInterfaces
{
    public interface ILocalizationManager //: IAbstractManager<LOCALIZATION> Tutaj nie mogę dziedziczyć po IAbstracManager
    {
        LOCALIZATION Get(string Locale);
        void Add(LOCALIZATION Entity);
        void Update(LOCALIZATION Entity);
        void Disable(string Locale);
        void Delete(string Locale);
        IEnumerable<LOCALIZATION> GetAllActive();
    }
}
