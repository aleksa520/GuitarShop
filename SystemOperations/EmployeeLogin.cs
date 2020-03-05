using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemOperations
{
    public class EmployeeLogin : CommonSystemOperation
    {
        public Employee Employee { get; private set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Employee = (Employee)obj;

            List<Employee> employees = Broker.Instance.GetList(obj).OfType<Employee>().ToList();

            foreach (Employee emp in employees)
            {
                if (emp.Username == Employee.Username && emp.Password == Employee.Password)
                {
                    return emp;
                }
            }
            throw new Exception("User Not Found!");
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
