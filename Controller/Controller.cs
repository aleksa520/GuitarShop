﻿using DatabaseBroker;
using Domain;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Controller
    {
        private static Controller instance;
        private Broker broker = new Broker();

        public static Controller Instance
        {
            get
            {
                if (instance == null) instance = new Controller();
                return instance;
            }
        }

        private Controller()
        { 
        }

        public Employee EmployeeLogin(string username, string password)
        {
            EmployeeStorage employeeStorage = new EmployeeStorage();

            List<Employee> employees = employeeStorage.GetEmployees();

            foreach(Employee emp in employees)
            {
                if(emp.Username == username && emp.Password == password)
                {
                    return emp;
                }
            }        
            throw new Exception("User Not Found!");
        }

        public Customer CustomerLogin(string username, string password)
        {
            List<Customer> customers = GetAllCustomers();

            foreach(Customer cust in customers)
            {
                if(cust.Username == username && cust.Password == password)
                {
                    return cust;
                }  
            }
            throw new Exception("User Not Found");
        }

        public List<Customer> GetAllCustomers()
        {
            broker.OpenConnection();
            List<Customer> customers = broker.GetAllCustomers();
            broker.CloseConnection();
            return customers;
        }

        public Customer CustomerRegistration(Customer customer)
        {
            List<Customer> customers = GetAllCustomers();
            
            foreach(Customer cust in customers)
            {
                if(cust.Username == customer.Username)
                {
                    throw new Exception("Username Allready Exists!");
                }
            }

            broker.OpenConnection();
            if(broker.CustomerRegistration(customer) == 0)
            {
                throw new Exception();
            }
            broker.CloseConnection();
            return customer;
        }

        public Employee Validation(Employee employee)
        {
            EmployeeStorage employeeStorage = new EmployeeStorage();

            List<Employee> employees = employeeStorage.GetEmployees();

            foreach(Employee emp in employees)
            {
                if(emp.Username == employee.Username)
                {
                    throw new Exception("Username Allready Exists!");
                }
            }

            return employee;
        }
    }
}