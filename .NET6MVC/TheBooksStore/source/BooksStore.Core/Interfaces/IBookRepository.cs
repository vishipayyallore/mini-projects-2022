using BooksStore.Core.Entities;

namespace BooksStore.Core.Interfaces
{

    public interface IBookRepository
    {
        Task<IEnumerable<Book?>> GetAllBooks();

        Task<Book?> GetBookById(Guid courseId);
    }

}
