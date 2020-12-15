using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public Book Book { get; set; }
        public decimal Price { get; set; }
        public string ShopCartID { get; set; }

    }
}
