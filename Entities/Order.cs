using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order:BaseEntity
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAdress { get; set; }
        public string OrderCode { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal FinalAmount { get; set; }
        public DateTime PlacedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool  IsDeleted { get; set; }
        public bool IActive { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
