using Entities;

namespace MVC.ViewModels
{
    public class BlogVM
    {
        public Blog singleBlog { get; set; }
        public List<Blog> SameBlogs { get; set; }
    }
}
