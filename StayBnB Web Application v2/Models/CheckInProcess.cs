using System.ComponentModel.DataAnnotations;

namespace StayBnB_Web_Application_v2.Models
{
    public class CheckInProcess
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }

        [StringLength(200)]
        public string? Title { get; set; }
        public string? StepsJson { get; set; }
        public DateTime? CreatedAt { get; set; }

        //nav property for hostproperty
        public HostProperty? HostProperty { get; set; }
    }
}
