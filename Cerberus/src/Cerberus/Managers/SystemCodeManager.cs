using Cerberus.Interfaces.ManagerInterfaces;
using Cerberus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Managers
{
    public class SystemCodeManager : ISystemCodeManager
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

        public SYSTEM_CODE Get(string Code)
        {
            SYSTEM_CODE entity = this.context.Set<SYSTEM_CODE>().Where(x => x.CODE == Code && x.IS_ACTIVE == true).First();
            return entity;
        }

        public void Add(SYSTEM_CODE Entity)
        {
            Entity.IS_ACTIVE = true;
            EntityEntry dbEntityEntry = this.context.Entry<SYSTEM_CODE>(Entity);
            this.context.Set<SYSTEM_CODE>().Add(Entity);
        }

        public void Update(SYSTEM_CODE Entity)
        {
            EntityEntry dbEntityEntry = this.context.Entry<SYSTEM_CODE>(Entity);
            Entity.IS_ACTIVE = true;
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Disable(string Code)
        {
            SYSTEM_CODE entity = this.context.Set<SYSTEM_CODE>().Where(x => x.CODE == Code).First();
            entity.IS_ACTIVE = false;
            EntityEntry dbEntityEntry = this.context.Entry<SYSTEM_CODE>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(string Code)
        {
            SYSTEM_CODE entity = this.context.Set<SYSTEM_CODE>().Where(x => x.CODE == Code).First();
            EntityEntry dbEntityEntry = this.context.Entry<SYSTEM_CODE>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public IEnumerable<SYSTEM_CODE> GetAllActive()
        {
            IEnumerable<SYSTEM_CODE> result = this.context.Set<SYSTEM_CODE>().Where(x => x.IS_ACTIVE == true);
            return result;
        }

        public SystemCodeManager(MainContext Context)
        {
            this.context = Context;
        }
    }
}
