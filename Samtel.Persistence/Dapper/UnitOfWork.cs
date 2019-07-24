using System;
using System.Data;
using Samtel.Application.BusinessService.Base;

namespace Samtel.Persistence.Dapper
{
    public class UnitOfWork : IUnitOfwork
    {
        public IContext Context { get; private set; }
        public IDbTransaction Transaction { get; private set; }

        public UnitOfWork(IContext context)
        {
            Context = context;
        }
        public IDbTransaction BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new NullReferenceException("Not finished previous transaction");
            }
            Transaction = Context.Connection.BeginTransaction();
            Context.CurrentTransaction = Transaction;
            return Transaction;
        }

        public void Commit()
        {
            try
            {
                if (Transaction != null)
                {
                    Transaction.Commit();
                    Transaction.Dispose();
                    Transaction = null;
                    Context.CurrentTransaction = null;
                }
                else
                {
                    throw new NullReferenceException("Tryed commit not opened transaction");
                }
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        public bool ExistsTransaction()
        {
            return Transaction != null;
        }

        public void Rollback()
        {
            try
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                    Transaction.Dispose();
                    Transaction = null;
                    Context.CurrentTransaction = null;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
            }
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
