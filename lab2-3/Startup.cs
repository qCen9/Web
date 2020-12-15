using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BookShop.Models.Interfaces;
using BookShop.Models.Repository;

namespace BookShop
{
    public class Startup
    {
        private IConfigurationRoot Configuration;

        // Подключение конфиг-файла dbsettings.json
        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Регистрация службы хранилища
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();

            // Подключение контекст БД
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Подключение сессии
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Разные корзины для разных пользователей
            services.AddScoped(sp => Cart.GetCart(sp));

            // Поддержка контроллеров и представлений (MVC)
            services.AddControllersWithViews()
                // Совместимость с ASP.NET Core 3.0 (в случае обновлений)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // В процессе разработки видим подробную информацию об ошибках
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Маршрутизация
            app.UseRouting();
            // Статические файлы (css, js и т.д.)
            app.UseStaticFiles();
            // Cессии
            app.UseSession();

            // Для работы с контекстом БД
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DBObject.Initial(context);
            }

            // Регистрация нужных нам маршрутов
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
