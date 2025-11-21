namespace DomainLayer.Models
{
    public class Prescription : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Notes { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
    }

}
