using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Manufacturer : IDomainObject
    { 
        public int Id { get; set; }
        public string Name { get; set; }

        public string Table => "Manufacturer";

        public string FullTable => throw new NotImplementedException();

        public string InsertValues => throw new NotImplementedException();

        public string UpdateValues => throw new NotImplementedException();

        public string Join => "";

        public string SearchId => throw new NotImplementedException();

        public object ColumnId => throw new NotImplementedException();

        public object Get => "SELECT Id, Name FROM";

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
                Manufacturer man = new Manufacturer
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                };
                list.Add(man);
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
            return Name;
        }
    }
}
