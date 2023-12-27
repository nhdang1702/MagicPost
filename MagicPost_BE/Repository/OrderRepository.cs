using MagicPost_BE.Data;
using MagicPost_BE.Interfaces;
using MagicPost_BE.Models;

namespace MagicPost_BE.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        

        public ICollection<Order> GetOrderSentTo(int OfficeId) 
        {
            return _context.Orders.Where(e => e.SentFrom.OfficeId == OfficeId).ToList();
        }

        public ICollection<Order> GetOrdersByCustomerId(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }
    }
}
