using Microsoft.EntityFrameworkCore;
using NetWebAPI.Models.Entities;

namespace NetWebAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Mobile",
                    Description = "Iphone Mobile Phone",
                    Price = 50000
                },
                new Product
                {
                    ID = 2,
                    Name = "Shoes",
                    Description = "Men's Wear Shoes",
                    Price = 3000
                }
                );
        }
    }
}
