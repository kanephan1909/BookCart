using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopCart_CodeFirst.Models
{
    public class BookContext : DbContext
    {
        public BookContext() { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }

    }
}