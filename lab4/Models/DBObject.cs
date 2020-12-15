using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Models
{
    public class DBObject
    {
        public static void Initial(AppDbContext context)
        {
            
            if (!context.Category.Any())
                context.Category.AddRange(Categories.Select(c => c.Value));
        
            if(!context.Book.Any())
            {
                context.AddRange(
                    new Book
                    {
                        BookName = "Анна Кaренина",
                        Author = "Лев Толстой",
                        Img = "/img/Anna.jpg",
                        Price = 50,
                        Category = Categories["Художественная литература"]
                    },
                     new Book
                     {
                         BookName = "Вечера на хуторе близ Диканьки",
                         Author = "Николай Гоголь",
                         Img = "/img/vecher.jpg",
                         Price = 50,
                         Category = Categories["Художественная литература"]
                     },
                     new Book
                      {
                         BookName = "Обломов",
                         Author = "Гончаров И.А.",
                         Img = "/img/oblomov.jpg",
                         Price = 50,
                         Category = Categories["Художественная литература"]
                      },
                     new Book
                      {
                         BookName = "Объектно-ориентированное программирование в С++",
                         Author = "Лафоре Роберт",
                         Img = "/img/qw.jpg",
                         Price = 300,
                         Category = Categories["Техническая литература"]
                      },
                     new Book
                      {
                         BookName = "Программирование для Android",
                         Author = "Денис Колисниченко",
                         Img = "/img/android.jpg",
                         Price = 200,
                         Category = Categories["Техническая литература"]
                      },
                     new Book
                      {
                         BookName = "КОМПАС-3D",
                         Author = "Л. В. Теверовский",
                         Img = "/img/kompas.jpg",
                         Price = 200,
                         Category = Categories["Техническая литература"]
                      },
                     new Book
                      {
                         BookName = "Стив Джобс",
                         Author = "Уолтер Айзексон",
                         Img = "/img/stiv.jpg",
                         Price = 100,
                         Category = Categories["История"]
                      },
                     new Book
                      {
                         BookName = "Тайна перевала Дятлова",
                         Author = "Николай Андреев",
                         Img = "/img/tayna.jpg",
                         Price = 50,
                         Category = Categories["История"]
                      },
                     new Book
                      {
                         BookName = "Вторая мировая война",
                         Author = "Уинстон Черчилль",
                         Img = "/img/cherchill.jpg",
                         Price = 50,
                         Category = Categories["История"]
                      },
                     new Book
                      {
                         BookName = "Артемис Фаул",
                         Author = "Йон Колфер",
                         Img = "/img/artemis.jpg",
                         Price = 150,
                         Category = Categories["Фантастика"]
                      },
                     new Book
                      {
                         BookName = "Гарри Поттер",
                         Author = "Дж. К. Роулинг",
                         Img = "/img/artemis.jpg",
                         Price = 200,
                         Category = Categories["Фантастика"]
                      },
                     new Book
                      {
                         BookName = "11/22/63",
                         Author = "Стивен Кинг",
                         Img = "/img/stiven.jpg",
                         Price = 400,
                         Category = Categories["Фантастика"]
                      });
            }

            context.SaveChanges();
        }
        

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var listCategory = new Category[]
                    {
                        new Category { CategoryName = "Художественная литература", Description = "desc1" },
                        new Category { CategoryName = "Техническая литература", Description = "desc2" },
                        new Category { CategoryName = "История", Description = "desc3" },
                        new Category { CategoryName = "Фантастика", Description = "desc4" }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in listCategory)
                        category.Add(el.CategoryName, el);
                }

                return category;
            }
        }
    }
}
