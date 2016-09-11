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

        protected void BeginTransaction()
        {
            this.transaction = this.context.Database.BeginTransaction();
        }

        protected void CommitTransaction()
        {
            this.transaction.Commit();
        }

        protected void RollbackTransaction()
        {
            this.transaction.Rollback();
        }

        public AbstractManager(MainContext Context)
        {
            this.context = Context;
        }
    }
}
