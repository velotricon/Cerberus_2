using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Cerberus.Interfaces;
using Cerberus.Interfaces.ManagerInterfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Cerberus.AbstractClasses
{
    public abstract class AbstractManager<T> : IAbstractManager<T> where T : class, IEntityBasic, new ()
    {
        protected MainContext context;

        #region to_be_deleted
        //protected IDbContextTransaction transaction;
        //protected bool saving_changes_enabled;


        ///// <summary>
        ///// To be used within one instance of a class
        ///// </summary>
        //protected void begin_transaction()
        //{
        //    this.transaction = this.context.Database.BeginTransaction();
        //}

        ///// <summary>
        ///// To be used within one instance of a class
        ///// </summary>
        //protected void commit_transaction()
        //{
        //    this.transaction.Commit();
        //}

        ///// <summary>
        ///// To be used within one instance of a class
        ///// </summary>
        //protected void rollback_transaction()
        //{
        //    this.transaction.Rollback();
        //}

        ///// <summary>
        ///// Save changes on context but only when saving changes is enabled.
        ///// </summary>
        //protected void save_changes()
        //{
        //    if(this.saving_changes_enabled)
        //    {
        //        this.context.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns>Object meant to be passed to other managers witch require to share the same transaction.</returns>
        //public TransactionContext BeginTransaction()
        //{
        //    return new TransactionContext()
        //    {
        //        Context = this.context,
        //        TransactionObject = this.context.Database.BeginTransaction()
        //    };
        //}

        //public void SetSharedTransactionContext(TransactionContext Transaction)
        //{
        //    if (Transaction.TransactionObject == null) throw new Exception("Transaction object is null");
        //    this.context = Transaction.Context;
        //    this.transaction = Transaction.TransactionObject;
        //}

        //public void DisableSavingChanges()
        //{
        //    this.saving_changes_enabled = false;
        //}

        //public void EnableSabingChanges()
        //{
        //    this.saving_changes_enabled = true;
        //}
        #endregion

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

        public T Get(int Id)
        {
            T entity = this.context.Set<T>().Where(x => x.ID == Id && x.IS_ACTIVE == true).First();
            return entity;
        }

        public virtual void Add(T Entity)
        {
            Entity.IS_ACTIVE = true;
            EntityEntry dbEntityEntry = this.context.Entry<T>(Entity);
            this.context.Set<T>().Add(Entity);
        }

        public virtual void Update(T Entity)
        {
            EntityEntry dbEntityEntry = this.context.Entry<T>(Entity);
            Entity.IS_ACTIVE = true;
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Disable(int Id)
        {
            T entity = this.context.Set<T>().Where(x => x.ID == Id).First();
            entity.IS_ACTIVE = false;
            EntityEntry dbEntityEntry = this.context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(int Id)
        {
            T entity = this.context.Set<T>().Where(x => x.ID == Id).First();
            EntityEntry dbEntityEntry = this.context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAllActive()
        {
            IEnumerable<T> result = this.context.Set<T>().Where(x => x.IS_ACTIVE == true);
            return result;
        }

        public AbstractManager(MainContext Context)
        {
            this.context = Context;
            //this.EnableSabingChanges();
        }
    }
}
