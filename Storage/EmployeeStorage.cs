using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class EmployeeStorage
    {
        private List<Employee> employees;

        public EmployeeStorage()
        {
            employees = new List<Employee>() {
                new Employee
                {
                    FirstName = "Mika",
                    LastName = "Mikic",
                    JMBG = "1232134354356",
                    Username= "mika",
                    Password = "mika"
                },
                new Employee
                {
                    FirstName = "Pera",
                    LastName = "Peric",
                    JMBG = "1232134354356",
                    Username= "pera",
                    Password = "pera"
                }
            };
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
