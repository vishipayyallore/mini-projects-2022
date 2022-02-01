using BooksStore.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Web.Controllers
{

    public class BooksController : Controller
    {

        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookRepository bookRepository, ILogger<BooksController> logger)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _logger.LogInformation($"BooksController() at {nameof(BooksController)}");
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation($"Starting Index() at {nameof(BooksController)}");

            // TODO: Remove this line.
            await Task.Delay(500);

            var items = await _bookRepository.GetAllBooks();

            return View(items);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            _logger.LogInformation($"Starting Details() at {nameof(BooksController)}");

            var book = await _bookRepository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

    }

}
