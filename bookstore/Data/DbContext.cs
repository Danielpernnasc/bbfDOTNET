
using bookstore.models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
        : base(options) { }

        public DbSet<Books> Books { get; set; }

    }
}