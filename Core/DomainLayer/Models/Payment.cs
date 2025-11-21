namespace DomainLayer.Models
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = null!;

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;
    }

}
