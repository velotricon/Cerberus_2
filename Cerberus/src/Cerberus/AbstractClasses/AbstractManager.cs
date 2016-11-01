using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cerberus.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cerberus.AbstractClasses
{
    public abstract class AbstractManager
    {
        protected MainContext context;
        protected IDbContextTransaction transaction;
        protected bool saving_changes_enabled;


        /// <summary>
        /// To be used within one instance of a class
        /// </summary>
        protected void begin_transaction()
        {
            this.transaction = this.context.Database.BeginTransaction();
        }

        /// <summary>
        /// To be used within one instance of a class
        /// </summary>
        protected void commit_transaction()
        {
            this.transaction.Commit();
        }

        /// <summary>
        /// To be used within one instance of a class
        /// </summary>
        protected void rollback_transaction()
        {
            this.transaction.Rollback();
        }

        /// <summary>
        /// Save changes on context but only when saving changes is enabled.
        /// </summary>
        protected void save_changes()
        {
            if(this.saving_changes_enabled)
            {
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Object meant to be passed to other managers witch require to share the same transaction.</returns>
        public TransactionContext BeginTransaction()
        {
            return new TransactionContext()
            {
                Context = this.context,
                TransactionObject = this.context.Database.BeginTransaction()
            };
        }

        public void SetSharedTransactionContext(TransactionContext Transaction)
        {
            if (Transaction.TransactionObject == null) throw new Exception("Transaction object is null");
            this.context = Transaction.Context;
            this.transaction = Transaction.TransactionObject;
        }

        public void DisableSavingChanges()
        {
            this.saving_changes_enabled = false;
        }

        public void EnableSabingChanges()
        {
            this.saving_changes_enabled = true;
        }

        public AbstractManager(MainContext Context)
        {
            this.context = Context;
            this.EnableSabingChanges();
        }
    }
}
