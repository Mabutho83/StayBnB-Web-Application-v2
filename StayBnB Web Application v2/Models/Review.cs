using System.ComponentModel.DataAnnotations;

namespace StayBnB_Web_Application_v2.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string? ReviewerId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        [StringLength(1000)]
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        //nav prop for hostproperty
        public HostProperty? HostProperty { get; set; }

        //nav prop for applicationuser
        public ApplicationUser? Reviewer { get; set; }


    }
}
