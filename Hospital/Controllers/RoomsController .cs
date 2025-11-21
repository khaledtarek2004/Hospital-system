using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAll()
        {
            var rooms = await _roomService.GetAllAsync();
            return Ok(rooms);
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<RoomDto>> GetById(int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<RoomDto>> Create([FromBody] CreateRoomDto dto)
        {
            var room = await _roomService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
        }

       
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<RoomDto>> Update(int id, [FromBody] UpdateRoomDto dto)
        {
            var updatedRoom = await _roomService.UpdateAsync(id, dto);
            if (updatedRoom == null) return NotFound();
            return Ok(updatedRoom);
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _roomService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
