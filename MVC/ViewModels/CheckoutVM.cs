using Entities;

namespace MVC.ViewModels
{
    public class CheckoutVM
    {
        public List<int> ProductIds { get; set; }
        public List<Product> Products { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAdress { get; set; }
    }
}
