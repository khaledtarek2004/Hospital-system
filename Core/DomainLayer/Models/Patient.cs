namespace DomainLayer.Models
{
    public class Patient : BaseEntity
    {
        public Guid ApplicationUserId { get; set; }
        public User ApplicationUser { get; set; }

        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string? Address { get; set; }
        public string ContactNumber { get; set; }
        public string InsuranceDetails { get; set; }
        public string EmergencyContact { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public ICollection<Invoice> invoices { get; set; } = new List<Invoice>();
        public ICollection<Prescription> prescriptions { get; set; } = new List<Prescription>();
    }

}
