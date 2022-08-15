using Microsoft.AspNetCore.Mvc;

namespace eRestaurant.Web.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
