using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Book" },
                new Category { Id = 2, Name = "Adventure" },
                new Category { Id = 3, Name = "Sci-Fi" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Harry Potter", Price = 100, CategoryId = 1 },
                new Product { Id = 2, Name = "Captain Hook", Price = 300, CategoryId = 2 },
                new Product { Id = 3, Name = "Star Trek", Price = 600, CategoryId = 3 }
                );
        }
    }
}
