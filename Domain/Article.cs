using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public ArticleType ArticleType { get; set; }
    }
}
