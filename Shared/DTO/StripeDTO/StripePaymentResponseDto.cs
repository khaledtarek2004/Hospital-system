using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.StripeDTO
{
    public class StripePaymentResponseDto
    {
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
    }

}
