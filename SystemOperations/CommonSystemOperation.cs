using System;
using DatabaseBroker;
using Domain;

namespace SystemOperations
{
    public abstract class CommonSystemOperation
    {
        protected abstract void Validation(IDomainObject obj);
        protected abstract object ExecuteSpecificOperation(IDomainObject obj);
        public object Execute(IDomainObject obj)
        {
            try
            {
                Validation(obj);
                Broker.Instance.OpenConnection();
                Broker.Instance.BeginTransaction();
                object result = ExecuteSpecificOperation(obj);
                Broker.Instance.Commit();
                return result;
            }
            catch (Exception e)
            {
                String s = e.Message;
                Broker.Instance.Rollback();
                return null;
                throw;
            }
            finally
            {
                Broker.Instance.CloseConnection();
            }
        }
    }
}