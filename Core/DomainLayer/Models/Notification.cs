namespace DomainLayer.Models
{
    public class Notification : BaseEntity
    {
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; }
        public int? UserId { get; set; }
    }

}
