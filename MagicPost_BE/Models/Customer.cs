using System.ComponentModel.DataAnnotations;

namespace MagicPost_BE.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
