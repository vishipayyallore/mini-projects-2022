using BooksStore.Web.Reposotory;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Web.Controllers
{

    public class BooksController : Controller
    {

        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<IActionResult> Index()
        {
            var items = await _bookRepository.GetAllBooks();

            return View(items);
        }
    }

}
