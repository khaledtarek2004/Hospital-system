using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.StripeDTO
{
    public class StripePaymentRequestDto
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
    }

}
