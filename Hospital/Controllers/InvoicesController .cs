using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

       
        [HttpGet]
        [Authorize(Roles ="Admin,Staff")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAll()
        {
            var invoices = await _invoiceService.GetAllAsync();
            return Ok(invoices);
        }

       
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Staff,Patient")]
        public async Task<ActionResult<InvoiceDto>> GetById(int id)
        {
            var invoice = await _invoiceService.GetByIdAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<InvoiceDto>> Create([FromBody] CreateInvoiceDto dto)
        {
            var invoice = await _invoiceService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = invoice.Id }, invoice);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<InvoiceDto>> Update(int id, [FromBody] UpdateInvoiceDto dto)
        {
            var updatedInvoice = await _invoiceService.UpdateAsync(id, dto);
            if (updatedInvoice == null) return NotFound();
            return Ok(updatedInvoice);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _invoiceService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
