using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemOperations
{
    public class GetCustomers : CommonSystemOperation
    {
        public Customer Customer { get; private set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {           
            Customer = (Customer)obj;
            return Broker.Instance.GetList(obj).OfType<Customer>().ToList();
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
