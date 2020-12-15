using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using BookShop.Models.Interfaces;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class CartController : Controller
    {
        private IBooksRepository bookRep;
        private readonly Cart cart;

        public CartController(IBooksRepository bookRep, Cart cart)
        {
            this.bookRep = bookRep;
            this.cart = cart;
        }

        public async Task<ViewResult> Index()
        {
            cart.ListCartItems = await cart.GetCartItems();
            var obj = new CartListViewModel
            {
                Cart = cart,
                SumCartItem = cart.SumCartItem()
            };

            return View(obj);
        }

        // Переадрисовка на корзину после добавления товара
        public async Task<RedirectToActionResult> AddToCart(int id)
        {
            var item = bookRep.GetBook(id);
            if (item != null)
            {
                await cart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }


        // Переадрисовка на корзину после удаление товара
        public async Task<RedirectToActionResult> RemoveFromCart(int id)
        {
            await cart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}
