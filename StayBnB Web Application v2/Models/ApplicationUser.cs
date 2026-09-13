using Microsoft.AspNetCore.Identity;

namespace StayBnB_Web_Application_v2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property 
        public ICollection<HostProperty>? HostProperties { get; set; } = new List<HostProperty>();
        //nav property for bookings
        public ICollection<Booking>? Bookings { get; set; } = new List<Booking>();

        //nav property for reviews
        public ICollection<Review>? Reviews { get; set; } = new List<Review>();
    }
}
