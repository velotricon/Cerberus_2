using Cerberus.AbstractClasses;
using Cerberus.Interfaces;
using Cerberus.Interfaces.ManagerInterfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Models
{
    public class TransactionContext
    {
        private IDbContextTransaction transaction;
        private MainContext shared_context;
        private List<IContextUser> context_users;

        private void set_common_context()
        {
            if(context_users.Count > 0)
            {
                this.shared_context = this.context_users.First().GetContext();
                foreach(IContextUser user in this.context_users)
                {
                    user.SetContext(this.shared_context);
                }
            }
        }

        public void BeginTransaction()
        {
            this.set_common_context();
            this.transaction = this.shared_context.Database.BeginTransaction();
        }

        public void CommtTransaction()
        {
            this.shared_context.SaveChanges();
            this.transaction.Commit();
        }

        public void RollbackTransaction()
        {
            this.transaction.Rollback();
        }

        public void ClearContextUsersList()
        {
            this.context_users.Clear();
        }

        public void AddContextUser(IContextUser NewContextUser)
        {
            this.context_users.Add(NewContextUser);
        }

        public TransactionContext()
        {
            this.context_users = new List<IContextUser>();
            this.shared_context = null;
            this.transaction = null;
        }
    }
}
