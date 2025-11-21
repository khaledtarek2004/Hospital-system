using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO.StripeDTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IStripeService _stripeService;

        public StripeController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] StripePaymentRequestDto dto)
        {
            var result = await _stripeService.CreatePaymentIntent(dto);
            return Ok(result);
        }
    }
}
