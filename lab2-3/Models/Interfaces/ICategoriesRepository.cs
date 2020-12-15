using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Interfaces
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
