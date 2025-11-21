using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAll()
        {
            var appointments = await _appointmentService.GetAllAsync();
            return Ok(appointments);
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AppointmentDto>> GetById(int id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }


        [HttpPost]
        [Authorize(Roles ="Doctor, Admin")]
        public async Task<ActionResult<AppointmentDto>> Create([FromBody] CreateAppointmentDto dto)
        {
            var appointment = await _appointmentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, appointment);
        }

       
        [HttpPut("{id}")]
        [Authorize(Roles = "Doctor, Admin")]
        public async Task<ActionResult<AppointmentDto>> Update(int id, [FromBody] UpdateAppointmentDto dto)
        {
            var updatedAppointment = await _appointmentService.UpdateAsync(id, dto);
            if (updatedAppointment == null) return NotFound();
            return Ok(updatedAppointment);
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles =" Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _appointmentService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
