using eRestaurant.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace eRestaurant.Web.Controllers
{

    public class PersonsController : Controller
    {
        public IActionResult PersonsIndex()
        {
            IEnumerable<PersonModel> persons = GetDummyPersons();

            return View(persons);
        }

        private static IEnumerable<PersonModel> GetDummyPersons()
        {
            return new List<PersonModel>
            {
                new PersonModel { PersonId = 1, Name = "Shiva", Gender = "Male", City = "Hyderabad" },
                new PersonModel { PersonId = 2, Name = "Manish", Gender = "Male", City = "Jaipur" }
            };
        }
    }

}
