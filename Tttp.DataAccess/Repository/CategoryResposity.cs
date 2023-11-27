using Microsoft.EntityFrameworkCore.Storage;
using WebApplicationTEST.DataAccess.Repository.InterfaceRepository;
using WebApplicationTEST.Models;
using Database = WebApplicationTEST.DataAccess.Temp_Database.Database;

namespace WebApplicationTEST.DataAccess.Repository
{
    public class CategoryResposity : Repository<CategoryModel>, ICategoryRepository
    {
        private Database _db;
        public CategoryResposity(Database db) : base(db)
        {
            _db = db;
        }

        public void Update(CategoryModel category)
        {
            _db.Categories.Update(category);
        }
    }
}
