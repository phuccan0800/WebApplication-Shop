using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationTEST.DataAccess.Repository.InterfaceRepository;
using WebApplicationTEST.Models;

namespace Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ProductModel> products = _unitOfWork.Product.GetAll("Category");
            return View(products);
        }
        public IActionResult Details(int id)
        {
            ProductModel product = _unitOfWork.Product.Get(u=>u.Id==id, includeProperties:"Category");
            return View(product);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
