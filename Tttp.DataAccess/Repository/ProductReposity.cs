using Microsoft.EntityFrameworkCore.Storage;
using WebApplicationTEST.DataAccess.Repository.InterfaceRepository;
using WebApplicationTEST.Models;
using Database = WebApplicationTEST.DataAccess.Temp_Database.Database;

namespace WebApplicationTEST.DataAccess.Repository
{
    public class ProductRepository : Repository<ProductModel>, IProductReposity
    {
        private Database _db;
        public ProductRepository(Database db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductModel product)
        {
            var objFromdb = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (objFromdb != null)
            {
                objFromdb.Name = product.Name;
                objFromdb.Description = product.Description;
                objFromdb.Author = product.Author;
                objFromdb.Price = product.Price;    
                objFromdb.CategoryId = product.CategoryId;
                if (objFromdb.ImgUrl != null)
                {
                    objFromdb.ImgUrl = product.ImgUrl;
                }


            }
        }
    }
}
