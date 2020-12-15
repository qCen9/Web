using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> AllCategory { get; set; }
    }
}
