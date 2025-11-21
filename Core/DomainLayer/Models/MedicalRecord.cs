namespace DomainLayer.Models
{
    public class MedicalRecord : BaseEntity
    {
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
    }

}
