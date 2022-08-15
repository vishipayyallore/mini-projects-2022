using eRestaurant.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace eRestaurant.Web.Controllers
{

    public class PersonsController : Controller
    {
        static List<PersonDto> personList = new();

        public IActionResult PersonsIndex()
        {

            if (!personList.Any())
            {
                personList.AddRange(GetDummyPersons());
            }

            return View(personList);
        }

        [HttpGet]
        public IActionResult PersonCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonCreate(PersonDto personDto)
        {
            personList.Add(personDto);

            return RedirectToAction(nameof(PersonsIndex));
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
