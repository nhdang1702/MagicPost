using MagicPost_BE.Enum;
using MagicPost_BE.Models;

namespace MagicPost_BE.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public OrderStatus Status { get; set; }
        public Office SentFrom { get; set; }
        public Office SentTo { get; set; }
        public Office CurrentOffice { get; set; }
    }
}
