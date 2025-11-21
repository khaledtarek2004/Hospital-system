using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

       
        [HttpGet]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<ActionResult<IEnumerable<MedicineDto>>> GetAll()
        {
            var medicines = await _medicineService.GetAllAsync();
            return Ok(medicines);
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Doctor,Pharmacist")]
        public async Task<ActionResult<MedicineDto>> GetById(int id)
        {
            var medicine = await _medicineService.GetByIdAsync(id);
            if (medicine == null) return NotFound();
            return Ok(medicine);
        }

      
        [HttpPost]
        [Authorize(Roles ="Pharmacist")]
        public async Task<ActionResult<MedicineDto>> Create([FromBody] CreateMedicineDto dto)
        {
            var medicine = await _medicineService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = medicine.Id }, medicine);
        }

        
        [HttpPut("{id}")]
        [Authorize(Roles = "Pharmacist")]
        public async Task<ActionResult<MedicineDto>> Update(int id, [FromBody] UpdateMedicineDto dto)
        {
            var updatedMedicine = await _medicineService.UpdateAsync(id, dto);
            if (updatedMedicine == null) return NotFound();
            return Ok(updatedMedicine);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _medicineService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
