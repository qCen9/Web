using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BookShop.Models;
using BookShop.Models.Interfaces;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BooksController : Controller
    {
      
        private readonly IBooksRepository allBook;
        private readonly ICategoriesRepository allCategory;

        public BooksController(IBooksRepository allBook, ICategoriesRepository allCategory)
        {
            this.allBook = allBook;
            this.allCategory = allCategory;
        }

        [Route("Books/List")]
        public ViewResult List()
        {
            IEnumerable<Category> category = null;

            category = allCategory.AllCategories.OrderBy(i => i.ID);

            var categoryObj = new CategoryListViewModel
            {
                AllCategory = category
            };

            return View(categoryObj);
        }

        [HttpGet]
        [Route("Books/List/{category}")]
        public ActionResult BooksPartial(string category)
        {
            IEnumerable<Book> books = null;

            if (string.IsNullOrEmpty(category))
            {
                books = allBook.AllBooks.OrderBy(i => i.BookID);
            }
            else
            {
                if (string.Equals("Художественная литература", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = allBook.AllBooks.Where(i => i.Category.CategoryName.Equals("Художественная литература")).OrderBy(i => i.CategoryID);
                }
                else if (string.Equals("Техническая литература", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = allBook.AllBooks.Where(i => i.Category.CategoryName.Equals("Техническая литература")).OrderBy(i => i.CategoryID);
                }
                else if (string.Equals("История", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = allBook.AllBooks.Where(i => i.Category.CategoryName.Equals("История")).OrderBy(i => i.CategoryID);
                }
                else if (string.Equals("Фантастика", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = allBook.AllBooks.Where(i => i.Category.CategoryName.Equals("Фантастика")).OrderBy(i => i.CategoryID);
                }
            }

            var bookObj = new BooksListViewModel
            {
                AllBooks = books
            };

            return PartialView(bookObj);
        }
    }
}
