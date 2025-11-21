using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

       
        [HttpGet]
        [Authorize(Roles = "Admin,Staff,Patient")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetAll()
        {
            var payments = await _paymentService.GetAllAsync();
            return Ok(payments);
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Staff,Patient")]
        public async Task<ActionResult<PaymentDto>> GetById(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

       
        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<PaymentDto>> Create([FromBody] CreatePaymentDto dto)
        {
            var payment = await _paymentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = payment.Id }, payment);
        }

        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Staff,Patient")]
        public async Task<ActionResult<PaymentDto>> Update(int id, [FromBody] UpdatePaymentDto dto)
        {
            var updatedPayment = await _paymentService.UpdateAsync(id, dto);
            if (updatedPayment == null) return NotFound();
            return Ok(updatedPayment);
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _paymentService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
