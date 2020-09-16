using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Employee : Person, IDomainObject
    {
        public string JMBG { get; set; }
        public DateTime Birthday { get; set; }

        public string Table => "Employee";

        public string FullTable => "Employee e";

        public string InsertValues => throw new NotImplementedException();

        public string UpdateValues => throw new NotImplementedException();

        public string Join => "";

        public string SearchId => throw new NotImplementedException();

        public object ColumnId => throw new NotImplementedException();

        public object Get => "SELECT * FROM";

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
                list.Add(emp);
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
