using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTEST.Models;

namespace WebApplicationTEST.DataAccess.Repository.InterfaceRepository
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        void Update(CategoryModel product);
    }
}
