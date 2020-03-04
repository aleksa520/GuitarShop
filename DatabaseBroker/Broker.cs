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
        private static Broker instance;
        SqlConnection connection;
        SqlTransaction transaction;

        public static Broker Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Broker();
                }
                return instance;
            }
        }
        private Broker()
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
    }
}
