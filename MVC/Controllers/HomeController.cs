using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;
using Services;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductManager _productManager;

        public HomeController(ILogger<HomeController> logger, ProductManager productManager)
        {
            _logger = logger;
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            IndexVM VM = new()
            {
                GetSlider = _productManager.GetSlider(),
                ProductList=_productManager.GetAllProduct(),
                ProductsNew=_productManager.ProductNew(5),
                Blogs=_productManager.GetBlogs(),

            };
       
            return View(VM);
        }

        public IActionResult Contact()
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