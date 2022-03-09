using Entities;

namespace MVC.ViewModels
{
    public class IndexVM
    {
        public List<Product>? GetSlider{ get; set; }
        public List<Product>? ProductList { get; set; }
        public List<Product>? ProductsNew { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
