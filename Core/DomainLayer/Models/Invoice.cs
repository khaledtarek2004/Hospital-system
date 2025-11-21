namespace DomainLayer.Models
{
    public class Invoice : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }

}
