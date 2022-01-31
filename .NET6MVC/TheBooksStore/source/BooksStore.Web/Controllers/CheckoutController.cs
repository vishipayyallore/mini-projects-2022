using BooksStore.Core.Interfaces;
using BooksStore.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public CheckoutController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<IActionResult> Purchase(Guid id)
        {

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
