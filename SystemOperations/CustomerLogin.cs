using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemOperations
{
    public class CustomerLogin : CommonSystemOperation
    {
        public Customer Customer { get; private set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Customer = (Customer)obj;

            List<Customer> customers = Broker.Instance.GetList(obj).OfType<Customer>().ToList();

            foreach (Customer cust in customers)
            {
                if (cust.Username == Customer.Username && cust.Password == Customer.Password)
                {
                    return cust;
                }
            }
            throw new Exception("User Not Found!");
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
