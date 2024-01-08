using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using WebApplication3.Areas.Admin.Controllers;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repository.iRepository;

namespace WebApp
{
    public class Tests
    {
        [Test]
        public async Task TestControllerIndexAsync_InMemory()
        {
            // Configure in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Add data
            using (var context = new ApplicationDbContext(options))
            {
                context.Products.AddRange(new List<Product>
                {
                    new Product { Id = 1, Name = "Harry Potter", Price = 100, CategoryId = 1},
                    new Product { Id = 2, Name = "Captain Hook", Price = 300, CategoryId = 2 },
                    new Product { Id = 3, Name = "Star Trek", Price = 600, CategoryId = 3 }
                });
                await context.SaveChangesAsync();
            }

            // Mock the Product repository
            var mockProductRepo = new Mock<IProductRepository>();
            mockProductRepo.Setup(repo => repo.GetAll())
                .Returns(new List<Product>
                {
                    new Product { Id = 1, Name = "Harry Potter", Price = 100, CategoryId = 1},
                    new Product { Id = 2, Name = "Captain Hook", Price = 300, CategoryId = 2 },
                    new Product { Id = 3, Name = "Star Trek", Price = 600, CategoryId = 3 }
                }.AsQueryable());

            // Mock the IUnitOfWork
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Product).Returns(mockProductRepo.Object);

            // Test controller logic
            var controller = new ProductController(mockUnitOfWork.Object);
            var result = controller.Index() as ViewResult;
            var model = result?.Model as List<Product>;

            // Assertions
            Assert.IsNotNull(result);
            Assert.AreEqual(3, model?.Count);
        }
    }
}

