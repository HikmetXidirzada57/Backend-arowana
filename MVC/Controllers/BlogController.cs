using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using Services;

namespace MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager;

        public BlogController(BlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        public IActionResult BlogDetails(int? id)
        {
            if (id == null) return NotFound();
            var findBlog = _blogManager.SingleBlog(id);
            if(findBlog == null) return NotFound();

            BlogVM vm = new()
            {
                singleBlog=_blogManager.SingleBlog(id),
                SameBlogs = _blogManager.FindBlogId(findBlog.BlogCategoyID,id)
            };
            return View(vm);
        }
    }
}
