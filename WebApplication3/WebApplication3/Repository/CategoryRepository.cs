using System.Linq.Expressions;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repository.IRepository;

namespace WebApplication3.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
