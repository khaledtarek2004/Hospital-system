using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public InvoiceMinimalDto Invoice { get; set; }
    }

    public class CreatePaymentDto
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int InvoiceId { get; set; }
    }

    public class UpdatePaymentDto
    {
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public int? InvoiceId { get; set; }
    }

    public class PaymentMinimalDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
    }

}
