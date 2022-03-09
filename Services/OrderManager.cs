using DataAcces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    
    public class OrderManager
    {
        private readonly ApplicationDbContext _context;

        public OrderManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public List<Order> GetOrdrs(Order order)
        {
           return _context.Orders.ToList();
           
        }
    }
}
