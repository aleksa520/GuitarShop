using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Item
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public double Value { get; set; }
        public Article Article { get; set; }
    }
}
