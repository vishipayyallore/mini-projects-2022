using BooksStore.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BooksStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _logger.LogInformation($"HomeController() at {nameof(HomeController)}");
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"Starting Index() at {nameof(HomeController)}");

            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation($"Starting Privacy() at {nameof(HomeController)}");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError($"Inside Error() at {nameof(HomeController)}");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}