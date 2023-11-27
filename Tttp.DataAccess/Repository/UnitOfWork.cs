using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTEST.DataAccess.Repository.InterfaceRepository;
using WebApplicationTEST.DataAccess.Temp_Database;

namespace WebApplicationTEST.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Database _db;
        public ICategoryRepository Category { get; private set; }  
        public IProductReposity Product { get ; private set; } 

        public UnitOfWork(Database db) 
        {
            _db = db;
            Category = new CategoryResposity(_db);
            Product = new ProductRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
