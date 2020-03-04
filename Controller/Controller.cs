using DatabaseBroker;
using Domain;
using Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations;

namespace Controller
{
    public class Controller
    {
        private static Controller instance;

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
            List<Employee> employees = GetAllEmployees();

            foreach (Employee emp in employees)
            {
                if (emp.Username == username && emp.Password == password)
                {
                    return emp;
                }
            }
            throw new Exception("User Not Found!");
        }

        public bool DeleteArticle(Article article)
        {
            DeleteArticle da = new DeleteArticle();
            return (bool)da.Execute(article);
        }
        public bool UpdateArticle(Article article)
        {
            UpdateArticle ua = new UpdateArticle();
            return (bool)ua.Execute(article);
        }

        public bool AddArticle(Article article)
        {
            AddArticle add = new AddArticle();
            return (bool)add.Execute(article);
        }

        public bool AddBill(Bill bill)
        {
            AddBill ab = new AddBill();

            ab.Execute(bill);
            Broker.Instance.OpenConnection();
            int id = Broker.Instance.GetId(bill);
            Broker.Instance.CloseConnection();

            foreach (var item  in bill.Items)
            {
                item.Bill = bill;
                item.Bill.Id = id;
            }

            AddBillItems abi = new AddBillItems();

            foreach (var item in bill.Items)
            {
                abi.Execute(item);
            }

            return true;
        }

        public List<Article> GetArticles()
        {
            GetArticles ga = new GetArticles();
            return ga.Execute(new Article()) as List<Article>;
        }

        public List<Bill> GetBills()
        {
            GetBills gb = new GetBills();
            return gb.Execute(new Bill()) as List<Bill>;
        }

        private List<Employee> GetAllEmployees()
        {
            try
            {
                Broker.Instance.OpenConnection();
                return Broker.Instance.GetList(new Employee()).OfType<Employee>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Broker.Instance.CloseConnection();
            }
        }

        public Customer CustomerLogin(string username, string password)
        {
            List<Customer> customers = GetAllCustomers();

            foreach (Customer cust in customers)
            {
                if (cust.Username == username && cust.Password == password)
                {
                    return cust;
                }
            }
            throw new Exception("User Not Found");
        }

        public List<Customer> GetAllCustomers()
        {
            GetCustomers ga = new GetCustomers();
            return ga.Execute(new Customer()) as List<Customer>;
        }

        public Customer CustomerRegistration(Customer customer)
        {
            List<Customer> customers = GetAllCustomers();

            foreach (Customer cust in customers)
            {
                if (cust.Username == customer.Username)
                {
                    throw new Exception("Username Allready Exists!");
                }
            }

            AddCustomer addc = new AddCustomer();
            addc.Execute(customer);

            return customer;
        }

        public Employee Validation(Employee employee)
        {
            EmployeeStorage employeeStorage = new EmployeeStorage();

            List<Employee> employees = employeeStorage.GetEmployees();

            foreach (Employee emp in employees)
            {
                if (emp.Username == employee.Username)
                {
                    throw new Exception("Username Allready Exists!");
                }
            }
            return employee;
        }

        public List<ArticleType> GetAllArticleTypes()
        {
            SystemOperations.GetArticleTypes gat = new SystemOperations.GetArticleTypes();
            return gat.Execute(new ArticleType()) as List<ArticleType>;

        }
        public List<Manufacturer> GetAllManufacturers()
        {
            GetManufacturers gm = new GetManufacturers();
            return gm.Execute(new Manufacturer()) as List<Manufacturer>;
        }
    }
}
