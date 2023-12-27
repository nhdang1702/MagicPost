using MagicPost_BE.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicPost_BE.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string? FullName { get; set; }
        public Role Role { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        
        public Office? WorkAt { get; set; }
        
    }
}
