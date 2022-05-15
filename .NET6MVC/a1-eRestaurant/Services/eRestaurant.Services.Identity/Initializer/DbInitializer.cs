using eRestaurant.Services.Identity.Common;
using eRestaurant.Services.Identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace eRestaurant.Services.Identity.Initializer
{

    public class DbInitializer : IDbInitializer
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(Constants.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(Constants.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Constants.Customer)).GetAwaiter().GetResult();
            }
            else { return; }

            ApplicationUser adminUser = new()
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "Ben",
                LastName = "Admin"
            };

            _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, Constants.Admin).GetAwaiter().GetResult();

            _ = _userManager.AddClaimsAsync(adminUser, new Claim[] {
                new Claim(JwtClaimTypes.Name, $"{adminUser.FirstName} {adminUser.LastName}"),
                new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                new Claim(JwtClaimTypes.Role,Constants.Admin),
            }).Result;

            ApplicationUser customerUser = new()
            {
                UserName = "customer1@gmail.com",
                Email = "customer1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "Ben",
                LastName = "Cust"
            };

            _userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, Constants.Customer).GetAwaiter().GetResult();

            _ = _userManager.AddClaimsAsync(customerUser, new Claim[] {
                new Claim(JwtClaimTypes.Name, $"{customerUser.FirstName} {customerUser.LastName}"),
                new Claim(JwtClaimTypes.GivenName,customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,customerUser.LastName),
                new Claim(JwtClaimTypes.Role,Constants.Customer),
            }).Result;
        }
    }

}
