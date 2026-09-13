namespace StayBnB_Web_Application_v2.Models
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string? ImageUrl { get; set; }

        public HostProperty? HostProperty { get; set; }
    }
}
