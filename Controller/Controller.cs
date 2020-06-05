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
            return (bool)ab.Execute(bill);
        }

        public List<Article> GetArticles()
        {
            GetArticles ga = new GetArticles();
            return ga.Execute(new Article()) as List<Article>;
        }

        public List<Bill> GetBills()
        {
            GetBills gb = new GetBills();
            GetItems gi = new GetItems();
            List<Bill> bills = gb.Execute(new Bill()) as List<Bill>;

            foreach (Bill b in bills)
            {
                List<Item> items = gi.Execute(new Item()) as List<Item>;
                b.Items = new List<Item>();
                foreach (Item i in items)
                {
                    if (i.Bill.Id == b.Id)
                    {
                        b.Items.Add(i);
                    }
                }
            }
            return bills;
        }

        public List<Employee> GetEmployees()
        {
            GetEmployees ge = new GetEmployees();
            return ge.Execute(new Employee()) as List<Employee>;
        }

        public Customer CustomerLogin(string username, string password)
        {
            SystemOperations.CustomerLogin cl = new SystemOperations.CustomerLogin();
            return cl.Execute(new Customer()
            {
                Username = username,
                Password = password
            }) as Customer;
        }

        public Employee EmployeeLogin(string username, string password)
        {
            SystemOperations.EmployeeLogin el = new SystemOperations.EmployeeLogin();
            return el.Execute(new Employee()
            {
                Username = username,
                Password = password
            }) as Employee;
        }

        public Customer CustomerRegistration(Customer customer)
        {
            Register reg = new Register();
            return reg.Execute(customer) as Customer;
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
