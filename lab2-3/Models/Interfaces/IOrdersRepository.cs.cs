using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Interfaces
{
    public interface IOrdersRepository
    {
        Task CreateOrder(Order order);
    }
}
