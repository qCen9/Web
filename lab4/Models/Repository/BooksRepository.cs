using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Models.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext appDbContext;
        
        public BooksRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Book> AllBooks => appDbContext.Book.Include(c => c.Category);

        public Book GetBook(int BookID) => appDbContext.Book.FirstOrDefault(p => p.BookID == BookID);
    }
}
