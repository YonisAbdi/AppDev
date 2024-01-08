using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repository.IRepository;

namespace WebApplication3.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IProductRepository Product { get; set; }
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
