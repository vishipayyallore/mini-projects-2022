using eRestaurant.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace eRestaurant.Web.Controllers
{

    public class PersonsController : Controller
    {
        public IActionResult PersonsIndex()
        {
            IEnumerable<PersonDto> persons = GetDummyPersons();

            return View(persons);
        }

        private static IEnumerable<PersonDto> GetDummyPersons()
        {
            return new List<PersonDto>
            {
                new PersonDto { PersonId = 1, Name = "Shiva", Gender = "Male", City = "Hyderabad" },
                new PersonDto { PersonId = 2, Name = "Manish", Gender = "Male", City = "Jaipur" }
            };
        }
    }

}
