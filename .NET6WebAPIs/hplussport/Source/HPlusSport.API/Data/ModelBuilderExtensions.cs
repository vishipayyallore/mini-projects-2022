using HPlusSport.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Data
{

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Name = "Active Wear - Men" },
                new Category { Name = "Active Wear - Women" },
                new Category { Name = "Mineral Water" },
                new Category { Name = "Publications" },
                new Category { Name = "Supplements" });

            var idOne = Guid.NewGuid();
            var idTwo = Guid.NewGuid();
            var idThree = Guid.NewGuid();
            var idFour = Guid.NewGuid();
            var idFive = Guid.NewGuid();

            modelBuilder.Entity<Product>().HasData(
                new Product { CategoryId = idOne, Name = "Grunge Skater Jeans", Sku = "AWMGSJ", Price = 68, IsAvailable = true },
                new Product { CategoryId = idOne, Name = "Polo Shirt", Sku = "AWMPS", Price = 35, IsAvailable = true },
                new Product { CategoryId = idOne, Name = "Skater Graphic T-Shirt", Sku = "AWMSGT", Price = 33, IsAvailable = true },
                new Product { CategoryId = idOne, Name = "Slicker Jacket", Sku = "AWMSJ", Price = 125, IsAvailable = true },
                new Product { CategoryId = idOne, Name = "Thermal Fleece Jacket", Sku = "AWMTFJ", Price = 60, IsAvailable = true },
                new Product { CategoryId = idOne, Name = "Unisex Thermal Vest", Sku = "AWMUTV", Price = 95, IsAvailable = true },
                new Product { CategoryId = idOne, Name = "V-Neck Pullover", Sku = "AWMVNP", Price = 65, IsAvailable = true },
                new Product { CategoryId = idOne, Name = "V-Neck Sweater", Sku = "AWMVNS", Price = 65, IsAvailable = true },
                new Product { CategoryId = idOne, Name = "V-Neck T-Shirt", Sku = "AWMVNT", Price = 17, IsAvailable = true },
                new Product { CategoryId = idTwo, Name = "Bamboo Thermal Ski Coat", Sku = "AWWBTSC", Price = 99, IsAvailable = true },
                new Product { CategoryId = idTwo, Name = "Cross-Back Training Tank", Sku = "AWWCTT", Price = 0, IsAvailable = false },
                new Product { CategoryId = idTwo, Name = "Grunge Skater Jeans", Sku = "AWWGSJ", Price = 68, IsAvailable = true },
                new Product { CategoryId = idTwo, Name = "Slicker Jacket", Sku = "AWWSJ", Price = 125, IsAvailable = true },
                new Product { CategoryId = idTwo, Name = "Stretchy Dance Pants", Sku = "AWWSDP", Price = 55, IsAvailable = true },
                new Product { CategoryId = idTwo, Name = "Ultra-Soft Tank Top", Sku = "AWWUTT", Price = 22, IsAvailable = true },
                new Product { CategoryId = idTwo, Name = "Unisex Thermal Vest", Sku = "AWWUTV", Price = 95, IsAvailable = true },
                new Product { CategoryId = idTwo, Name = "V-Next T-Shirt", Sku = "AWWVNT", Price = 17, IsAvailable = true },
                new Product { CategoryId = idThree, Name = "Blueberry Mineral Water", Sku = "MWB", Price = 2.8M, IsAvailable = true },
                new Product { CategoryId = idThree, Name = "Lemon-Lime Mineral Water", Sku = "MWLL", Price = 2.8M, IsAvailable = true },
                new Product { CategoryId = idThree, Name = "Orange Mineral Water", Sku = "MWO", Price = 2.8M, IsAvailable = true },
                new Product { CategoryId = idThree, Name = "Peach Mineral Water", Sku = "MWP", Price = 2.8M, IsAvailable = true },
                new Product { CategoryId = idThree, Name = "Raspberry Mineral Water", Sku = "MWR", Price = 2.8M, IsAvailable = true },
                new Product { CategoryId = idThree, Name = "Strawberry Mineral Water", Sku = "MWS", Price = 2.8M, IsAvailable = true },
                new Product { CategoryId = idFour, Name = "In the Kitchen with H+ Sport", Sku = "PITK", Price = 24.99M, IsAvailable = true },
                new Product { CategoryId = idFive, Name = "Calcium 400 IU (150 tablets)", Sku = "SC400", Price = 9.99M, IsAvailable = true },
                new Product { CategoryId = idFive, Name = "Flaxseed Oil 100 mg (90 capsules)", Sku = "SFO100", Price = 12.49M, IsAvailable = true },
                new Product { CategoryId = idFive, Name = "Iron 65 mg (150 caplets)", Sku = "SI65", Price = 13.99M, IsAvailable = true },
                new Product { CategoryId = idFive, Name = "Magnesium 250 mg (100 tablets)", Sku = "SM250", Price = 12.49M, IsAvailable = true },
                new Product { CategoryId = idFive, Name = "Multi-Vitamin (90 capsules)", Sku = "SMV", Price = 9.99M, IsAvailable = true },
                new Product { CategoryId = idFive, Name = "Vitamin A 10,000 IU (125 caplets)", Sku = "SVA", Price = 11.99M, IsAvailable = true },
                new Product { CategoryId = idFive, Name = "Vitamin B-Complex (100 caplets)", Sku = "SVB", Price = 12.99M, IsAvailable = true },
                new Product { CategoryId = idFive, Name = "Vitamin C 1000 mg (100 tablets)", Sku = "SVC", Price = 9.99M, IsAvailable = true },
                new Product { CategoryId = idFive, Name = "Vitamin D3 1000 IU (100 tablets)", Sku = "SVD3", Price = 12.49M, IsAvailable = true });

            modelBuilder.Entity<User>().HasData(
                new User { Email = "adam@example.com" },
                new User { Email = "barbara@example.com" });
        }
    }

}
