namespace DomainLayer.Models
{
    public class Doctor : BaseEntity
    {
        public Guid ApplicationUserId { get; set; }
        public User ApplicationUser { get; set; }

        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Specialty { get; set; } = null!;

        public string Specialization { get; set; }
        public string Qualifications { get; set; }
        public int YearsOfExperience { get; set; }
        public string ClinicAddress { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }

}
