using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public decimal Price { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
