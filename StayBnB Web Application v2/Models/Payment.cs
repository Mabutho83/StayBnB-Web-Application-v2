using StayBnB_Web_Application_v2.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayBnB_Web_Application_v2.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public PaymentStatus? Status { get; set; }
        public DateTime CreatedAt { get; set; }

        //nav property for booking  
        public Booking? Booking { get; set; }

    }
}
