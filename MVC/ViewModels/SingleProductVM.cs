using Entities;

namespace MVC.ViewModels
{
    public class SingleProductVM
    {
        public Product? Product { get; set; }
        public List<Product>? Products { get; set; }
        public List<Categories> Categorys { get; set; }
        public List<Product>? sameProducts { get; set; }
    }
}
