using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Customer : Person, IDomainObject
    {
        public string Table => "Customer";

        public string FullTable => throw new NotImplementedException();

        public string InsertValues => $"'{FirstName}','{LastName}','{Username}','{Password}'";

        public string UpdateValues => throw new NotImplementedException();

        public string Join => "";

        public string SearchId => throw new NotImplementedException();

        public object ColumnId => throw new NotImplementedException();

        public object Get => "SELECT Id, FirstName, LastName, Username, Password FROM";

        public string Criteria { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Condition()
        {
            throw new NotImplementedException();
        }

        public List<IDomainObject> GetReaderResult(SqlDataReader reader)
        {
            List<IDomainObject> list = new List<IDomainObject>();
            while (reader.Read())
            {
                Customer customer = new Customer()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Username = reader.GetString(3),
                    Password = reader.GetString(4)
                };
                list.Add(customer);
            }
            reader.Close();
            return list;
        }

        public string SearchCriteria(int crit)
        {
            throw new NotImplementedException();
        }

        public string SearchWhere()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
