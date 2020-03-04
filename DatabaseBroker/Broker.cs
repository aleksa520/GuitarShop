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

        public List<IDomainObject> GetListFull(IDomainObject obj)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"{obj.Get} {obj.FullTable} {obj.Join}";
            SqlDataReader reader = command.ExecuteReader();
            return obj.GetReaderResult(reader);
        }

        public List<IDomainObject> GetList(IDomainObject obj)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"{obj.Get} {obj.Table} {obj.Join}";
            SqlDataReader reader = command.ExecuteReader();
            return obj.GetReaderResult(reader);
        }

        public bool Add(IDomainObject obj)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"INSERT INTO {obj.Table} VALUES({obj.InsertValues})";
            return command.ExecuteNonQuery() == 1;
        }

        public bool Update(IDomainObject obj)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"UPDATE {obj.Table} SET {obj.UpdateValues} {obj.SearchWhere()}";
            return command.ExecuteNonQuery() == 1;
        }

        public int GetId(IDomainObject obj)
        {
            try
            {
                SqlCommand command = new SqlCommand("", connection, transaction);
                command.CommandText = $"SELECT MAX ({obj.ColumnId.ToString()}) FROM {obj.Table}";
                int id = Int32.Parse(command.ExecuteScalar().ToString());
                return id;
            }
            catch (Exception)
            {
                return 1;
                throw;
            }
        }

        public bool Delete(IDomainObject obj)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"DELETE FROM {obj.Table} {obj.SearchWhere()}";
            return command.ExecuteNonQuery() == 1;
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

        public List<ArticleType> GetAllArticleTypes()
        {
            List<ArticleType> articleTypes = new List<ArticleType>();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ArticleType";
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ArticleType at = new ArticleType
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),                   
                };
                articleTypes.Add(at);
            }
            reader.Close();
            return articleTypes;
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Manufacturer";
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Manufacturer ma = new Manufacturer
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                };
                manufacturers.Add(ma);
            }
            reader.Close();
            return manufacturers;
        }
    }
}
