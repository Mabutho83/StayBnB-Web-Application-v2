namespace StayBnB_Web_Application_v2.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int PropertyId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
