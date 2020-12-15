using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.ViewModels
{
    public class CartListViewModel
    {
        public Cart Cart { get; set; }
        public decimal SumCartItem { get; set; }
    }
}
