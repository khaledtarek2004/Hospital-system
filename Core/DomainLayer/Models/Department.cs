namespace DomainLayer.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<Doctor> Doctors { get; set; } = null!;
    }

}
