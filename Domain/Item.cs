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
    public class Item : IDomainObject
    {
        [Browsable(false)]
        public int Id { get; set; }
        [Browsable(false)]
        public Bill Bill { get; set; }
        public Article Article { get; set; }
        public int Count { get; set; }
        public double Value
        {
            get
            {
                return Article.Price * Count;
            }
            set { }
        }

        [Browsable(false)]
        public string Table => "Item";
        [Browsable(false)]
        public string FullTable => "Item i";
        [Browsable(false)]
        public string InsertValues => $"{Id},{Bill.Id},{Count},{Value},{Article.Id}";
        [Browsable(false)]
        public string UpdateValues => throw new NotImplementedException();
        [Browsable(false)]
        public string Join => "JOIN Article a on(a.Id = i.Article)";
        [Browsable(false)]
        public string SearchId => throw new NotImplementedException();
        [Browsable(false)]
        public object ColumnId => "Id";
        [Browsable(false)]
        public object Get => "SELECT i.Id, i.BillId, i.Count, a.Name, a.Price FROM";
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
                Item item = new Item() { };
                item.Id = reader.GetInt32(0);

                item.Bill = new Bill()
                {
                    Id = reader.GetInt32(1)
                };

                item.Count = reader.GetInt32(2);

                item.Article = new Article()
                {
                    Name = reader.GetString(3),
                    Price = reader.GetDouble(4)
                };

                list.Add(item);
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
