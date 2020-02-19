using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Serializable]
    public class Bill
    {
        public int Id { get; set; }
        public double TotalValue { get; set; }
        public DateTime Date { get; set; }
        public List<Item> Items { get; set; }
    }
}
