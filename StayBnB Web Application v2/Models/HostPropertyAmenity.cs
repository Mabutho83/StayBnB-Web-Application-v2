namespace StayBnB_Web_Application_v2.Models
{
    public class HostPropertyAmenity
    {
        //surrogate key
        public int Id { get; set; }
        public int HostPropertyId { get; set; }
        public int AmenityId { get; set; }
        //nav property for HostProperty
        public HostProperty? HostProperty { get; set; }
        //nav property for Amenity
        public Amenity? Amenity { get; set; }
    }
}
