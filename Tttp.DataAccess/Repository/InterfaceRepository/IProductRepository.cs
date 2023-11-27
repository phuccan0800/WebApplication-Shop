using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTEST.Models;

namespace WebApplicationTEST.DataAccess.Repository.InterfaceRepository
{
    public interface IProductReposity : IRepository<ProductModel>
    {
        void Update(ProductModel product);
    }
}
