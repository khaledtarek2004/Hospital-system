using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

       
        [HttpGet]
        [Authorize(Roles = "Admin,Staff,Patient")]
        public async Task<ActionResult<IEnumerable<PrescriptionDto>>> GetAll()
        {
            var prescriptions = await _prescriptionService.GetAllAsync();
            return Ok(prescriptions);
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Staff,Patient")]
        public async Task<ActionResult<PrescriptionDto>> GetById(int id)
        {
            var prescription = await _prescriptionService.GetByIdAsync(id);
            if (prescription == null) return NotFound();
            return Ok(prescription);
        }

       
        [HttpPost]
        [Authorize(Roles = "Admin,Patient")]
        public async Task<ActionResult<PrescriptionDto>> Create([FromBody] CreatePrescriptionDto dto)
        {
            var prescription = await _prescriptionService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = prescription.Id }, prescription);
        }

        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<PrescriptionDto>> Update(int id, [FromBody] UpdatePrescriptionDto dto)
        {
            var updatedPrescription = await _prescriptionService.UpdateAsync(id, dto);
            if (updatedPrescription == null) return NotFound();
            return Ok(updatedPrescription);
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _prescriptionService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
