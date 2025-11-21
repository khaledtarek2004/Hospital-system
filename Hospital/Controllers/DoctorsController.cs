using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll()
        {
            var doctors = await _doctorService.GetAllAsync();
            return Ok(doctors);
        }

       
        [HttpGet("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<DoctorDto>> GetById(int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

       
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<DoctorDto>> Create([FromBody] CreateDoctorDto dto)
        {
            var doctor = await _doctorService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
        }

        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<ActionResult<DoctorDto>> Update(int id, [FromBody] UpdateDoctorDto dto)
        {
            var updatedDoctor = await _doctorService.UpdateAsync(id, dto);
            if (updatedDoctor == null) return NotFound();
            return Ok(updatedDoctor);
        }

       
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _doctorService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
