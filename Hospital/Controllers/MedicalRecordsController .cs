using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordsController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        
        [HttpGet]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<ActionResult<IEnumerable<MedicalRecordDto>>> GetAll()
        {
            var records = await _medicalRecordService.GetAllAsync();
            return Ok(records);
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<ActionResult<MedicalRecordDto>> GetById(int id)
        {
            var record = await _medicalRecordService.GetByIdAsync(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult<MedicalRecordDto>> Create([FromBody] CreateMedicalRecordDto dto)
        {
            var record = await _medicalRecordService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = record.Id }, record);
        }

        
        [HttpPut("{id}")]
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult<MedicalRecordDto>> Update(int id, [FromBody] UpdateMedicalRecordDto dto)
        {
            var updatedRecord = await _medicalRecordService.UpdateAsync(id, dto);
            if (updatedRecord == null) return NotFound();
            return Ok(updatedRecord);
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _medicalRecordService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
