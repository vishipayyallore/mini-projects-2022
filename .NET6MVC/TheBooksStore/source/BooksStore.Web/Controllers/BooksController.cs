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
            await Task.Delay(500);

            var items = await _bookRepository.GetAllBooks();

            return View(items);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var book = await _bookRepository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

    }

}
