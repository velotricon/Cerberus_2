using Cerberus.Interfaces.ManagerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Cerberus.Managers
{
    public class LocalizationManager : ILocalizationManager
    {
        protected MainContext context;

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public MainContext GetContext()
        {
            return this.context;
        }

        public void SetContext(MainContext Context)
        {
            this.context = Context;
        }

        public LOCALIZATION Get(string Locale)
        {
            LOCALIZATION entity = this.context.Set<LOCALIZATION>().Where(x => x.LOCALE == Locale && x.IS_ACTIVE == true).First();
            return entity;
        }

        public void Add(LOCALIZATION Entity)
        {
            Entity.IS_ACTIVE = true;
            EntityEntry dbEntityEntry = this.context.Entry<LOCALIZATION>(Entity);
            this.context.Set<LOCALIZATION>().Add(Entity);
        }

        public void Update(LOCALIZATION Entity)
        {
            EntityEntry dbEntityEntry = this.context.Entry<LOCALIZATION>(Entity);
            Entity.IS_ACTIVE = true;
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Disable(string Locale)
        {
            LOCALIZATION entity = this.context.Set<LOCALIZATION>().Where(x => x.LOCALE == Locale).First();
            entity.IS_ACTIVE = false;
            EntityEntry dbEntityEntry = this.context.Entry<LOCALIZATION>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(string Locale)
        {
            LOCALIZATION entity = this.context.Set<LOCALIZATION>().Where(x => x.LOCALE == Locale).First();
            EntityEntry dbEntityEntry = this.context.Entry<LOCALIZATION>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public IEnumerable<LOCALIZATION> GetAllActive()
        {
            IEnumerable<LOCALIZATION> result = this.context.Set<LOCALIZATION>().Where(x => x.IS_ACTIVE == true);
            return result;
        }

        public LocalizationManager(MainContext Context)
        {
            this.context = Context;
        }
    }
}
