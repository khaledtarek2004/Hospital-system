namespace DomainLayer.Models
{
    public class Room : BaseEntity
    {
        public string RoomNumber { get; set; } = null!;
        public string Type { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }

}
