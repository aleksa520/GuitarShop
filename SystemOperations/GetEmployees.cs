using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemOperations
{
    public class GetEmployees : CommonSystemOperation
    {
        public Employee Employee { get; private set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Employee = (Employee)obj;
            return Broker.Instance.GetList(obj).OfType<Employee>().ToList();
        }

        protected override void Validation(IDomainObject obj)
        {
            if (!(obj is Employee))
            {
                throw new ArgumentException();
            }
        }
    }
}