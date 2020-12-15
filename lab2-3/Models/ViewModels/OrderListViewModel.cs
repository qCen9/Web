using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.ViewModels
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderDetail> OrderDetail { get; set; }
    }
}
