using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Models.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly Cart cart;

        public OrdersRepository(AppDbContext appDbContext, Cart cart)
        {
            this.appDbContext = appDbContext;
            this.cart = cart;
        }

        public async Task CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDbContext.Order.Add(order);
            await appDbContext.SaveChangesAsync();

            var items = cart.ListCartItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    BookID = el.Book.BookID,
                    OrderID = order.ID,
                    Price = el.Book.Price
                };
                appDbContext.OrderDetail.Add(orderDetail);
            }
            await appDbContext.SaveChangesAsync();
        }
    }
}
