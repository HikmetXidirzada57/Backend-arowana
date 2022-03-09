using DataAcces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
     

        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }
     
    }
}
