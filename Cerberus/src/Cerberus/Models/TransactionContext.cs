using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class TransactionContext
    {
        public IDbContextTransaction TransactionObject { get; set; }
        public MainContext Context { get; set; }

        public void CommtTransaction()
        {
            this.Context.SaveChanges();
            this.TransactionObject.Commit();
        }

        public void RollbackTransaction()
        {
            this.TransactionObject.Rollback();
        }
    }
}
