using StayBnB_Web_Application_v2.Enums;
using System.ComponentModel.DataAnnotations;

namespace StayBnB_Web_Application_v2.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        [StringLength(100)]
        public string? Title { get; set; }

        public NotificationType? Type { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
