namespace DomainLayer.Models
{
    public class Medicine : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }

}
