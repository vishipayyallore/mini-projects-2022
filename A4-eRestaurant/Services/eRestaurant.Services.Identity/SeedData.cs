using eRestaurant.Services.Identity.Common;
using eRestaurant.Services.Identity.Data;
using eRestaurant.Services.Identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Claims;

namespace eRestaurant.Services.Identity
{
    public class SeedData
    {
        public static void EnsureSeedData(WebApplication app)
        {
            const string PASSWORD = "Pass123$";

            using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context?.Database.Migrate();

            CreateRequiredRoles(scope);

            ApplicationUser? alice = GetApplicationUser("alice", "AliceSmith@mailinator.com", "Alice", "Smith", "111111111111");
            CreateApplicationUser(scope, alice, PASSWORD, Constants.Customer);

            ApplicationUser? bob = GetApplicationUser("bob", "BobSmith@mailinator.com", "Bob", "Smith", "2222222222");
            CreateApplicationUser(scope, bob, PASSWORD, Constants.Admin);

            ApplicationUser? robbie = GetApplicationUser("robbie", "RobertCollins@mailinator.com", "Robert", "Collins", "3333333333");
            CreateApplicationUser(scope, robbie, PASSWORD, Constants.Admin);

            ApplicationUser? swamy = GetApplicationUser("swamy", "SwamyPKV@mailinator.com", "Swamy", "PKV", "4444444444");
            CreateApplicationUser(scope, swamy, PASSWORD, Constants.Admin);
        }

        private static void CreateApplicationUser(IServiceScope scope, ApplicationUser? applicationUser, string password = "Pass123$",
            string userRole = Constants.Customer)
        {
            UserManager<ApplicationUser> _userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (_userManager.FindByNameAsync(applicationUser?.UserName).Result == null)
            {
                var result = _userManager.CreateAsync(applicationUser, password).Result;
                _userManager.AddToRoleAsync(applicationUser, userRole).GetAwaiter().GetResult();

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = _userManager.AddClaimsAsync(applicationUser, new Claim[]
                        {
                            new Claim(JwtClaimTypes.Name, $"{applicationUser.FirstName} {applicationUser.LastName}"),
                            new Claim(JwtClaimTypes.GivenName,applicationUser.FirstName),
                            new Claim(JwtClaimTypes.FamilyName,applicationUser.LastName),
                            new Claim(JwtClaimTypes.Role, userRole),
                        }).Result;

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                Log.Debug($"{applicationUser?.UserName} created");
            }
            else
            {
                Log.Debug($"{applicationUser?.UserName} already exists");
            }
        }

        private static void CreateRequiredRoles(IServiceScope scope)
        {
            var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (_roleManager.FindByNameAsync(Constants.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(Constants.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Constants.Customer)).GetAwaiter().GetResult();
            }
        }

        private static ApplicationUser GetApplicationUser(string userName, string email, string firstName,
            string lastName, string phoneNumber)
        {
            return new()
            {
                UserName = userName,
                Email = email,
                EmailConfirmed = true,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
            };
        }

    }
}