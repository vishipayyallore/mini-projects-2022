using BooksStore.Web.Core.Entities;

namespace BooksStore.Web.Reposotory
{

    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();

        Task<Book> GetById(Guid courseId);
    }

}
