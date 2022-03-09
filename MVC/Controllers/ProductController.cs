using Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using Services;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly CategoryManager _categoryManager;

        public ProductController(ProductManager productManager, CategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }

        public IActionResult Details(int? id)
        {
            if(id == null) return NotFound();
            var singleProduct = _productManager.GetProductId(id);
            var findProduct = _productManager.GetProductId(id);

            if (singleProduct == null) return NotFound();
            SingleProductVM sp = new SingleProductVM()
            {
                Product = singleProduct,
                Products = _productManager.GetAllProduct(),
                Categorys = _categoryManager.GetAll(),
                sameProducts=_productManager.FindCategory(findProduct.CategoryID,id.Value)
            };
            return View(sp);
        }
    }
}
