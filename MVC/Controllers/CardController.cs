using Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using Services;

namespace MVC.Controllers
{
    public class CardController : Controller
    {
       private readonly ProductManager _productManager;

        public CardController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var productIdList = Request.Cookies["cartItem"];
            List <Product> productList= null;
            CardVM VM = new();
            if (productIdList != null && productIdList!="")
            {
                List<int> productIds = productIdList.Split('-').Select(c => int.Parse(c)).ToList();
                 productList= _productManager.GetProductIds(productIds.Distinct());
                VM.ProductIds = productIds;
                VM.Products = productList;
            }

            return View(VM);
        }
    }
}
