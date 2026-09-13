using StayBnB_Web_Application_v2.Enums;

namespace StayBnB_Web_Application_v2.Models
{
    public class HostApplication
    {
        public int Id { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationStatus? Status { get; set; }
        public DateTime? AppliedAt { get; set; }
    }
}
