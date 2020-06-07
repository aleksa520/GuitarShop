using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Article : IDomainObject
    {
        [Browsable(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public ArticleType ArticleType { get; set; }

        public override string ToString()
        {
            return Name;
        }

        [Browsable(false)]
        public string Table => "Article";
        [Browsable(false)]
        public string FullTable => "Article a";
        [Browsable(false)]
        public string InsertValues => $"'{Name}',{Price},{Manufacturer.Id},{ArticleType.Id}";
        [Browsable(false)]
        public string UpdateValues => $"Name = '{Name}', Price = '{Price}', Manufacturer = {Manufacturer.Id}, ArticleType = {ArticleType.Id}";
        [Browsable(false)]
        public string Join => "JOIN Manufacturer m on (m.Id = a.Manufacturer) join ArticleType at on (at.Id= a.ArticleType)";
        [Browsable(false)]
        public string SearchId => $"WHERE a.Name like '%{Criteria}%'";
        [Browsable(false)]
        public object ColumnId => "";

        public static explicit operator Article(DataRow v)
        {
            throw new NotImplementedException();
        }

        [Browsable(false)]
        public object Get => "SELECT a.Id,a.Name,a.Price,a.Manufacturer,m.Name,a.ArticleType,at.Name FROM";
        [Browsable(false)]
        public string Criteria { get; set; }
        [Browsable(false)]
        public string Condition()
        {
            return "";
        }
        [Browsable(false)]
        public List<IDomainObject> GetReaderResult(SqlDataReader reader)
        {
            List<IDomainObject> list = new List<IDomainObject>();
            while (reader.Read())
            {
                Article article = new Article()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDouble(2),
                    Manufacturer = new Manufacturer()
                    {
                        Id = reader.GetInt32(3),
                        Name = reader.GetString(4)
                    },
                    ArticleType = new ArticleType()
                    {
                        Id = reader.GetInt32(5),
                        Name = reader.GetString(6)
                    }
                };
                list.Add(article);
            }
            reader.Close();
            return list;
        }
        [Browsable(false)]
        public string SearchCriteria(int crit)
        {
            return "";
        }
        [Browsable(false)]
        public string SearchWhere()
        {
            return $"WHERE Id = {Id}";
        }
    }
}
