using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.DataAccess.Repository.IRepository;
using SneakerShop.Models;
using SneakerShop.Utility;
using System.Diagnostics;
using System.Security.Claims;

namespace SneakerShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Search(string search)
        {

            List<Product> productsList = _unitOfWork.Product.Search(search);

            IEnumerable<ProductImage> productImages = _unitOfWork.ProductImage.GetAll();

            return View(productsList);
        }

        public IActionResult Index(string category)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


            if (claim != null)
            {
                HttpContext.Session.SetInt32(SD.ShoppingCart, _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUser.Id == claim.Value).Count());
            }

            IEnumerable<Product> productsList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");

            switch (category)
            {
                case "madeInUkUsa":
                    productsList = productsList.Where(u => u.CategoryId == 2);
                    break;
                case "forRun":
                    productsList = productsList.Where(u => u.CategoryId == 1);
                    break;
                case "forAsphalt":
                    productsList = productsList.Where(u => u.CategoryId == 3);
                    break;
                case "sportStyle":
                    productsList = productsList.Where(u => u.CategoryId == 4);
                    break;
                default:
                    break;

            }


            return View(productsList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.
                Get(u => u.Id == productId, includeProperties: "Category,ProductImages"),
                Count = 1,
                ProductId = productId
            };

            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            cart.ApplicationUserId = userId;

            ShoppingCart shoppingCart = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUser.Id == userId &&
            u.ProductId == cart.ProductId);

            if (shoppingCart != null)
            {
                shoppingCart.Count += cart.Count;
                _unitOfWork.ShoppingCart.Update(shoppingCart);
                _unitOfWork.Save();
              
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(cart); 
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.ShoppingCart, _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUser.Id == userId).Count());


            }





            TempData["success"] = "Кошик оновленно!";


            return RedirectToAction(nameof(Index));
        }



        public IActionResult Privacy()
        {
            return View();
        }


    }
}