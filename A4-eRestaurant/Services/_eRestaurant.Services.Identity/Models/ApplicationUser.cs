using Microsoft.AspNetCore.Identity;

namespace eRestaurant.Services.Identity.Models
{

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

}
