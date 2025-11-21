using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,Staff")]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Doctor,Staff")]
        public async Task<ActionResult<PatientDto>> GetById(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<PatientDto>> Create([FromBody] CreatePatientDto dto)
        {
            var patient = await _patientService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
        }

        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<PatientDto>> Update(int id, [FromBody] UpdatePatientDto dto)
        {
            var updatedPatient = await _patientService.UpdateAsync(id, dto);
            if (updatedPatient == null) return NotFound();
            return Ok(updatedPatient);
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _patientService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
