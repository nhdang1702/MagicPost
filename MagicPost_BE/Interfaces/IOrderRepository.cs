using MagicPost_BE.Models;

namespace MagicPost_BE.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetAllOrders();

        ICollection<Order> GetOrdersByCustomerId(int CustomerId);

        ICollection<Order> GetOrderSentTo(int OfficeId);
    }
}
