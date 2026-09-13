using System.ComponentModel.DataAnnotations;

namespace StayBnB_Web_Application_v2.Models
{
    public class Amenity
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]

        public string? IconClass { get; set; }

        //nav property for housepropertyamenity
        public ICollection<HostPropertyAmenity>? HostPropertyAmenity { get; set; } = new List<HostPropertyAmenity>();

    }
}
