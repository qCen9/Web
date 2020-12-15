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

        // ����������� ������-����� dbsettings.json
        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ����������� ������ ���������
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();

            // ����������� �������� ��
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // ����������� ������
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // ������ ������� ��� ������ �������������
            services.AddScoped(sp => Cart.GetCart(sp));

            // ��������� ������������ � ������������� (MVC)
            services.AddControllersWithViews()
                // ������������� � ASP.NET Core 3.0 (� ������ ����������)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // � �������� ���������� ����� ��������� ���������� �� �������
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // �������������
            app.UseRouting();
            // ����������� ����� (css, js � �.�.)
            app.UseStaticFiles();
            // C�����
            app.UseSession();

            // ��� ������ � ���������� ��
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DBObject.Initial(context);
            }

            // ����������� ������ ��� ���������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
