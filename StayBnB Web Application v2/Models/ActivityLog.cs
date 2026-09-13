using System.ComponentModel.DataAnnotations;
using StayBnB_Web_Application_v2.Enums;

namespace StayBnB_Web_Application_v2.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public string? UserId { get; set; }

        [StringLength(100)]
        public string? Action { get; set; }
        public ActivityType? ActivityType { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
