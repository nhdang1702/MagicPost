using MagicPost_BE.Enum;
using System.ComponentModel.DataAnnotations;

namespace MagicPost_BE.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public OrderStatus Status { get; set; }
        public Office? SentFrom { get; set; }
        public Office? SentTo { get; set; }
        public Office? CurrentOffice { get; set; }

        public Customer? Customer
        {
            get; set;
        }
    }
}
