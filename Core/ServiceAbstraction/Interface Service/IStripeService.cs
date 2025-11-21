using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO.StripeDTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IStripeService
    {
        Task<StripePaymentResponseDto> CreatePaymentIntent(StripePaymentRequestDto dto);
    }
}
