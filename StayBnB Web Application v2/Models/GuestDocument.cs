using StayBnB_Web_Application_v2.Enums;
using System.ComponentModel.DataAnnotations;

namespace StayBnB_Web_Application_v2.Models
{
    public class GuestDocument
    {
        public int Id { get; set; }
        public int GuestCheckInId { get; set; }
        [StringLength(100)]
        public string? DocumentType { get; set; }
        [StringLength(200)]

        public string? FileName { get; set; }
        public DocumentStatus? Status { get; set; }

        //nav property for GuestCheckIn
        public GuestCheckIn? GuestCheckIn { get; set; }

    }
}
