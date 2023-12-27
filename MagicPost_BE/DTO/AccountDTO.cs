using MagicPost_BE.Enum;
using MagicPost_BE.Models;

namespace MagicPost_BE.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public Role Role { get; set; }
        public string Phone { get; set; }
        public Office WorkAt  { get; set; }
    }
}
