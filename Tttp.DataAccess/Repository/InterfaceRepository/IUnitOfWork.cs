using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationTEST.DataAccess.Repository.InterfaceRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductReposity Product { get; }
        void Save();
    }
}
