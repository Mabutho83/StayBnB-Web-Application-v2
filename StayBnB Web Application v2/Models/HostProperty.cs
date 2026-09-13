using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayBnB_Web_Application_v2.Models
{
    public class HostProperty
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string? Title { get; set; }
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerNight { get; set; }
        // Foreign key for ApplicationUser
        public string? HostId { get; set; }

        public string? Address { get; set; }

        // Navigation property for ApplicationUser
        public ApplicationUser? ApplicationUser { get; set; }

        //nav property for hostproperty 
        public ICollection<Booking>? Bookings { get; set; } = new List<Booking>();

        //nav property for reviews
        public ICollection<Review>? Reviews { get; set; } = new List<Review>();

        //nav property for property images
        public ICollection<PropertyImage>? PropertyImages { get; set; } = new List<PropertyImage>();

        //nav property for checkinprocess
        public CheckInProcess? CheckInProcess { get; set; }

        //nav property for hostpropertyamenity
        public ICollection<HostPropertyAmenity>? PropertyAmenities { get; set; } = new List<HostPropertyAmenity>();

    }
}
