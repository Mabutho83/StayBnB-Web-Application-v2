using StayBnB_Web_Application_v2.Enums;

namespace StayBnB_Web_Application_v2.Models
{
    public class GuestCheckIn
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int CheckInProcessId { get; set; }
        public CheckInStatus? Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Navigation property for Booking
        public Booking? Booking { get; set; }

        //nav property for Guest documents
        public ICollection<GuestDocument>? GuestDocuments { get; set; } = new List<GuestDocument>();


    }
}
