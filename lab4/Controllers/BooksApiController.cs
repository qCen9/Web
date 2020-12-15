using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using BookShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly AppDbContext db;

        public BooksApiController(AppDbContext context)
        {
            db = context;
        }

        // GET api/booksapi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            return await db.Book.ToListAsync();
        }

        // GET api/booksapi/5
        [HttpGet("{id}", Name = "GetBook")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            Book book = await db.Book.FirstOrDefaultAsync(x => x.BookID == id);
            if (book == null)
                return NotFound();

            return new ObjectResult(book);
        }

        // POST api/booksapi
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            db.Book.Add(book);
            await db.SaveChangesAsync();
            return CreatedAtRoute("GetBook", new { id = book.BookID }, book);
        }

        // PUT api/booksapi/3
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutBook(int id,[FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            if (id != book.BookID)
                return NotFound();

            db.Update(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }

        // DELETE api/booksapi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            Book book = db.Book.FirstOrDefault(x => x.BookID == id);
            if (book == null)
                return NotFound();

            db.Book.Remove(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }
    }
}
