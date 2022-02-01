using BooksStore.Core.Interfaces;
using BooksStore.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(IBookRepository bookRepository, ILogger<CheckoutController> logger)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _logger.LogInformation($"CheckoutController() at {nameof(CheckoutController)}");
        }

        public async Task<IActionResult> Purchase(Guid id)
        {
            _logger.LogInformation($"Starting Purchase() at {nameof(CheckoutController)}");

            var book = await _bookRepository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookVM = new BookPurchaseVM
            {
                Id = book.Id,
                Description = book.Description,
                Author = book.Author,
                Picture = book.Picture,
                Title = book.Title,
                Price = book.Price,
                Nonce = ""
            };

            return View(bookVM);
        }

    }
}
