using HPlusSport.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Data
{

    /// <summary>
    /// 
    /// </summary>
    public class ShopDbContext : DbContext
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(c => c.Products)
                .WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Order>().HasMany(o => o.Products);

            modelBuilder.Entity<Order>().HasOne(o => o.User);

            modelBuilder.Entity<User>().HasMany(u => u.Orders)
                .WithOne(o => o.User).HasForeignKey(o => o.UserId);

            modelBuilder.Seed();
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Product>? Products { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Category>? Categories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Order>? Orders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<User>? Users { get; set; }
    }

}
