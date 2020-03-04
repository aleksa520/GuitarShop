using System;
using DatabaseBroker;
using Domain;

namespace SystemOperations
{
    public abstract class CommonSystemOperation
    {
        protected Broker broker = new Broker();
        protected abstract void Validation(IDomainObject obj);
        protected abstract object ExecuteSpecificOperation(IDomainObject obj);
        public object Execute(IDomainObject obj)
        {
            try
            {
                Validation(obj);
                broker.OpenConnection();
                broker.BeginTransaction();
                object result = ExecuteSpecificOperation(obj);
                broker.Commit();
                return result;
            }
            catch (Exception e)
            {
                String s = e.Message;
                broker.Rollback();
                return null;
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}