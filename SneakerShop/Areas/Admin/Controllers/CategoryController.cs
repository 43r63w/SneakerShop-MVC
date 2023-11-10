using Microsoft.AspNetCore.Mvc;
using SneakerShop.DataAccess.Repository.IRepository;
using SneakerShop.Models;

namespace SneakerShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {        
            return View();
        }


        public IActionResult Upsert(int id)
        {
            if (id == 0)
            {
                Category category = new Category();
                return View(category);
            }

            Category category1 = _unitOfWork.Category.Get(u => u.Id == id);

            return View(category1);
        }
        [HttpPost]
        public IActionResult Upsert(Category category)
        {
            if (category.Id == 0)
            {
                _unitOfWork.Category.Add(category);
            }
            else
            {
                _unitOfWork.Category.Update(category);
            }
            
            _unitOfWork.Save();

            TempData["success"] = "Категорію успішно оновленно/доданно!";

            return RedirectToAction("Index");
        }



        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categoriesList = _unitOfWork.Category.GetAll().ToList();

            return Json(new { data = categoriesList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Category.Get(u => u.Id == id);

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Категорію видаленно!" });

        }
        #endregion
    }
}
