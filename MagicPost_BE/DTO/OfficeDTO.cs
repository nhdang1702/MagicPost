using MagicPost_BE.Enum;

namespace MagicPost_BE.DTO
{
    public class OfficeDTO
    {
        public long OfficeId { get; set; }
        public string? OfficeName { get; set; }
        public OfficeType OfficeType { get; set; }
        public string? Address { get; set; }
    }
}
