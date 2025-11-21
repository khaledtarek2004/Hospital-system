using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ServiceAbstraction.Interface_Service;
using Shared.DTO.StripeDTO;
using Stripe;

namespace Service.Service
{
    public class StripeService : IStripeService
    {
        private readonly IConfiguration _config;

        public StripeService(IConfiguration config)
        {
            _config = config;
            StripeConfiguration.ApiKey = _config["Stripe:SecretKey"];
        }

        public async Task<StripePaymentResponseDto> CreatePaymentIntent(StripePaymentRequestDto dto)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(dto.Amount * 100), 
                Currency = _config["Stripe:Currency"],
                PaymentMethodTypes = new List<string> { "card" },
                Description = $"Payment for Invoice #{dto.InvoiceId}"
            };

            var service = new PaymentIntentService();
            var intent = await service.CreateAsync(options);

            return new StripePaymentResponseDto
            {
                ClientSecret = intent.ClientSecret,
                PaymentIntentId = intent.Id
            };
        }
    }
}
