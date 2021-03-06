using BooksStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Data
{

    public class BookStoreDbContext : DbContext
    {

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            BookStoreDbContextSeed.SeedDatabase(this);
        }

        public DbSet<Book>? Books { get; set; }
    }

}
