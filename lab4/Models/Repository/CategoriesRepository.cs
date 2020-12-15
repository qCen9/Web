using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models.Interfaces;

namespace BookShop.Models.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext appDbContext;

        public CategoriesRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => appDbContext.Category;
    }
}
