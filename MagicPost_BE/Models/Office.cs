using MagicPost_BE.Enum;
using System.ComponentModel.DataAnnotations;

namespace MagicPost_BE.Models
{
    public class Office
    {
        [Key]
        public long OfficeId { get; set; }
        public string? OfficeName { get; set; }
        public OfficeType OfficeType { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public ICollection<Account>? Accounts { get; set; }
    }
}
