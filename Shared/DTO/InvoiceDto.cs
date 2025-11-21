using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public List<PaymentDto> Payments { get; set; }
    }

    public class CreateInvoiceDto
    {
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public int PatientId { get; set; }
    }

    public class UpdateInvoiceDto
    {
        public decimal? TotalAmount { get; set; }
        public DateTime? Date { get; set; }
        public int? PatientId { get; set; }
    }

    public class InvoiceMinimalDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
