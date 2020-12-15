using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Interfaces
{
    public interface IBooksRepository
    {
        IEnumerable<Book> AllBooks { get; }

        Book GetBook(int BookID);
    }
}
