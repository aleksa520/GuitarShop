using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Serializable]
    public class Bill : IDomainObject
    {
        [Browsable(false)]
        public int Id { get; set; }

        public double Value { get; set; }
        public Employee Employee { get; set; }

        [Browsable(false)]
        public double TotalValue
        {
            get
            {
                return (Items.Sum(i => i.Value));
            }
            set
            {
                TotalValue = value;
            }
        }

        public DateTime Date { get; set; }
        public List<Item> Items { get; set; }
        public Customer Customer { get; set; }
        [Browsable(false)]
        public string Table => "Bill";
        [Browsable(false)]
        public string FullTable => "Bill b";
        [Browsable(false)]
        public string InsertValues => $"{TotalValue},'{Date}',{Customer.Id},1";
        [Browsable(false)]
        public string UpdateValues => throw new NotImplementedException();
        [Browsable(false)]
        public string Join => "JOIN Customer c on(c.Id = b.Customer) join Employee e on(e.Id = b.Employee)";
        [Browsable(false)]
        public string SearchId => throw new NotImplementedException();
        [Browsable(false)]
        public object ColumnId => "Id";
        [Browsable(false)]
        public object Get => "SELECT b.Id, b.TotalValue, b.Date, c.Id, c.FirstName, c.LastName, c.Username, c.Password, e.Id, e.FirstName, e.LastName, e.JMBG, e.Birthday, e.Username, e.Password FROM";
        [Browsable(false)]
        public string Criteria { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Browsable(false)]
        public string Condition()
        {
            throw new NotImplementedException();
        }
        [Browsable(false)]
        public List<IDomainObject> GetReaderResult(SqlDataReader reader)
        {
            List<IDomainObject> list = new List<IDomainObject>();
            while (reader.Read())
            {
                Bill bill = new Bill() { };
                bill.Id = reader.GetInt32(0);
                bill.Value = reader.GetFloat(1);
                bill.Date = reader.GetDateTime(2);

                bill.Customer = new Customer()
                {
                    Id = reader.GetInt32(3),
                    FirstName = reader.GetString(4),
                    LastName = reader.GetString(5),
                    Username = reader.GetString(6),
                    Password = reader.GetString(7)
                };

                bill.Employee = new Employee()
                {
                    Id = reader.GetInt32(8),
                    FirstName = reader.GetString(9),
                    LastName = reader.GetString(10),
                    JMBG = reader.GetString(11),
                    Birthday = reader.GetDateTime(12),
                    Username = reader.GetString(13),
                    Password = reader.GetString(14)
                };

                list.Add(bill);
            }
            reader.Close();
            return list;
        }
        [Browsable(false)]
        public string SearchCriteria(int crit)
        {
            throw new NotImplementedException();
        }
        [Browsable(false)]
        public string SearchWhere()
        {
            throw new NotImplementedException();
        }
    }
}
