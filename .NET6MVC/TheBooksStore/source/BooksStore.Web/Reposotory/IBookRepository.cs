using BooksStore.Web.Core.Entities;

namespace BooksStore.Web.Reposotory
{

    public interface IBookRepository
    {
        Task<IEnumerable<Book?>> GetAllBooks();

        Task<Book?> GetBookById(Guid courseId);
    }

}
