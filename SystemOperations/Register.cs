using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemOperations
{
    public class Register : CommonSystemOperation
    {
        public Customer Customer { get; private set; }

        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Customer = (Customer)obj;

            List<Customer> customers = Broker.Instance.GetList(obj).OfType<Customer>().ToList();
            List<Employee> employees = Broker.Instance.GetList(new Employee()).OfType<Employee>().ToList();

            foreach (Customer cust in customers)
            {
                if (cust.Username == Customer.Username)
                {
                    throw new Exception("Username Allready Exists!");
                }
            }

            foreach (Employee emp in employees)
            {
                if (emp.Username == Customer.Username)
                {
                    throw new Exception("Username Allready Exists!");
                }
            }

            Broker.Instance.Add(obj);

            return obj;
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
