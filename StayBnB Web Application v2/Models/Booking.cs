using StayBnB_Web_Application_v2.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayBnB_Web_Application_v2.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int HostPropertyId { get; set; }
        public string? GuestId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }
        public BookingStatus? Status { get; set; }
        public HostProperty? HostProperty { get; set; }
        //nav property for guestcheckin 
        public GuestCheckIn? GuestCheckIn { get; set; }

        //nav property for user
        public ApplicationUser? ApplicationUser { get; set; }

        //nav property for payment
        public Payment? Payment { get; set; }

    }
}
