using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOperations
{
    public class AddCustomer : CommonSystemOperation
    {
        public Customer Customer { get; private set; }

        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Customer = (Customer)obj;
            return Broker.Instance.Add(obj);
        }

        protected override void Validation(IDomainObject obj)
        {
            if (!(obj is Customer))
            {
                throw new ArgumentException();
            }
        }
    }
}
