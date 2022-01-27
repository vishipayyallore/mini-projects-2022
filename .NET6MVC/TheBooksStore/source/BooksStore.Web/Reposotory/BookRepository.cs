using BooksStore.Web.Core.Entities;
using BooksStore.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Web.Reposotory
{

    public class BookRepository : IBookRepository
    {

        private readonly BookStoreDbContext _bookStoreDbContext;

        public BookRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext ?? throw new ArgumentNullException(nameof(bookStoreDbContext));
        }

        public async Task<IEnumerable<Book?>> GetAllBooks()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return await _bookStoreDbContext.Books.ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async Task<Book?> GetBookById(Guid courseId)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var book = await _bookStoreDbContext.Books.FirstOrDefaultAsync(n => n.Id == courseId);
#pragma warning restore CS8604 // Possible null reference argument.

            if (book == null)
            {
                return null;
            }

            return book;
        }
    }

}
