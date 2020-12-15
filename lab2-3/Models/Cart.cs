using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Models
{
    public class Cart
    {
        private AppDbContext appDbContext;

        public Cart(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public string CartID { get; set; }
        public List<CartItem> ListCartItems { get; set; }
        
        public static Cart GetCart(IServiceProvider service)
        {
            // Создание сессии
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            // Для работы с БД
            var context = service.GetService<AppDbContext>();
            // Проверка наличия товара в корзине
            // В случае отсутствия: присваивания к товару новый ID
            string cartId = session.GetString("CartID") ?? Guid.NewGuid().ToString();
            session.SetString("CartID", cartId);

            return new Cart(context) { CartID = cartId };
        }

        // Добавление товаров в корзину
        public async Task AddToCart(Book book)
        {
            appDbContext.ShopCartItem.Add(
                new CartItem
                {
                    ShopCartID = CartID,
                    Book = book,
                    Price = book.Price
                });
            await appDbContext.SaveChangesAsync();
        }

        // Удаление товаров из корзины
        public async Task RemoveFromCart(int id)
        {
            var cartItem = await appDbContext.ShopCartItem.FindAsync(id);
            appDbContext.ShopCartItem.Remove(cartItem);
            await appDbContext.SaveChangesAsync();
        }

        // Взятие всех товаров из корзины
        public async Task<List<CartItem>> GetCartItems()
        {
            return await appDbContext.ShopCartItem.Where(c => c.ShopCartID == CartID).Include(s => s.Book).ToListAsync();
        }

        // Общая сумма товаров в корзине
        public decimal SumCartItem()
        {
            decimal sum = new decimal(0); 
            foreach (var el in ListCartItems)
                sum += el.Book.Price;
            return sum;
        }
    }
}
