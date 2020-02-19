using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBroker
{
    public class Broker
    {
        SqlConnection connection;
        SqlTransaction transaction;

        public Broker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GuitarShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Customer";
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Customer cust = new Customer
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Username = reader.GetString(3),
                    Password = reader.GetString(4)
                };
                customers.Add(cust);
            }
            reader.Close();
            return customers;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Employee";
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Employee emp = new Employee
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    JMBG = reader.GetString(3),
                    Birthday = reader.GetDateTime(4),
                    Username = reader.GetString(5),
                    Password = reader.GetString(6)
                };
                employees.Add(emp);
            }
            reader.Close();
            return employees;
        }

        public int CustomerRegistration(Customer customer)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Customer VALUES(@FirstName, @LastName, @Username, @Password)";
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@Username", customer.Username);
            command.Parameters.AddWithValue("@Password", customer.Password);
            return command.ExecuteNonQuery();
        }
    }
}
