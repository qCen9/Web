using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using BookShop.Models.Interfaces;
using BookShop.Models.Repository;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersRepository allOrders;
        private readonly Cart cart;

        public OrderController(IOrdersRepository allOrders, Cart cart)
        {
            this.allOrders = allOrders;
            this.cart = cart;
        }

        // Переход на страницу оформления заказа
        // Далее, отправка данных методом POST
        public IActionResult CheckOut()
        {
            return View();
        }

        // Создание, сохранение заказа
        [HttpPost]
        public async Task<IActionResult> CheckOut(Order order)
        {
            // Берем все товары из корзины
            cart.ListCartItems = await cart.GetCartItems();

            // Если товаров в корзине нет
            if (cart.ListCartItems.Count() == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }

            // Если все введенные значение верны
            if(ModelState.IsValid)
            {
                await allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        // Завершение оформления заказа
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ выполнен!";
            return View();
        }
    }
}
