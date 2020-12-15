using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
