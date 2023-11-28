using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using WebApplicationTEST.DataAccess.Repository.InterfaceRepository;
using WebApplicationTEST.DataAccess.Temp_Database;
using WebApplicationTEST.Models;
using WebApplicationTEST.Models.ViewModels;


namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<ProductModel> objProductList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();
            return View(objProductList);
        }
        public IActionResult Upsert(int? id)
        {
            
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
            Product = new ProductModel()
            };
            if (id==null || id ==0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _unitOfWork.Product.Get(u=>u.Id==id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"img\products");
                    
                    if (!string.IsNullOrEmpty(obj.Product.ImgUrl))
                    {
                        //delete old image
                        var oldImgPath = Path.Combine(wwwRootPath, obj.Product.ImgUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.Product.ImgUrl = @"\img\products\" + fileName;
                }
                else
                {
                    ProductVM productVM = new();
                    productVM.Product = _unitOfWork.Product.Get(u => u.Id == obj.Product.Id);
                    obj.Product.ImgUrl = productVM.Product.ImgUrl;
                }
                if (obj.Product.Id ==0)
                {
                    _unitOfWork.Product.Add(obj.Product);
                    TempData["success"] = "Product created successfully";
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                    TempData["success"] = "Product updated successfully";
                }
                
                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(obj);
            }
        }


 /*       public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ProductModel? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //ProductModel? ProductFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //ProductModel? ProductFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        [HttpPost]
        public IActionResult Edit(ProductModel obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
 */
/*        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ProductModel? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            ProductModel obk = _unitOfWork.Product.Get(u => u.Id == id);
            if (obk == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obk);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
*/
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            List<ProductModel> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new {data= objProductList});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var productDelete = _unitOfWork.Product.Get(u=>u.Id == id);
            if (productDelete == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, productDelete.ImgUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImgPath))
            {
                System.IO.File.Delete(oldImgPath);
            }

            _unitOfWork.Product.Remove(productDelete); _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion    
    }
}
