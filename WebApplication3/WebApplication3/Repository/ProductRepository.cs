using System.Linq.Expressions;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repository.IRepository;

namespace WebApplication3.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
