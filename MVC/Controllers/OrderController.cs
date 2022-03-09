using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using Services;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly OrderManager _orderManager;
        private readonly UserManager<EcommerceUser> _userManager;

        public OrderController(UserManager<EcommerceUser> userManager, ProductManager productManager, OrderManager orderManager)
        {
            _userManager = userManager;
            _productManager = productManager;
            _orderManager = orderManager;
        }

        public async Task<IActionResult> CheckOut()
        {
            var productIdList = Request.Cookies["cartItem"];
            List<Product> productList = null;
            CheckoutVM VM = new();
            if (productIdList != null && productIdList != "")
            {
                List<int> productIds = productIdList.Split('-').Select(c => int.Parse(c)).ToList();
                productList = _productManager.GetProductIds(productIds.Distinct());
                VM.ProductIds = productIds;
                VM.Products = productList;
                var selectedUser = await _userManager.FindByIdAsync(User.Identity.Name);
                if (selectedUser!=null)
                {
                    VM.CustomerId = selectedUser.Id;
                    VM.CustomerName = selectedUser.UserName;
                    VM.CustomerEmail = selectedUser.Email;
                    VM.CustomerPhone = selectedUser.PhoneNumber;
                }
                return View(VM);

            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult>  CheckOut(CheckoutVM checkvm)
        {
            Order order = new Order();
            var productIdList = Request.Cookies["cartItem"];
            List<Product> productList = null;

            if(productIdList != null && productIdList != "")
            {
                List<int>productIds=productIdList.Split("-").Select(c=>int.Parse(c)).ToList();
                productList = _productManager.GetProductIds(productIds.Distinct());
                order.CustomerPhone = checkvm.CustomerPhone;
                order.CustomerEmail = checkvm.CustomerEmail;
                order.CustomerName = checkvm.CustomerName;
                order.CustomerId = checkvm.CustomerId;
                order.OrderCode = Guid.NewGuid(). ToString();
                order.PlacedOn = DateTime.Now;
                order.OrderDetails = new List<OrderDetail>();
                order.OrderDetails.AddRange(productList.Select(c => new OrderDetail()
                {
                    ProductId=c.Id,
                    Quantity=(ushort)productIds.Where(p=>p==c.Id).Count(),
                    ItemPrice=c.Price,
                    Id=order.Id,
                }));
                 _orderManager.AddOrder(order);
                Response.Cookies.Delete("cartItem");
            }
            return View();
        }
        
    }
}
