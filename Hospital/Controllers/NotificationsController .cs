using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

       
        [HttpGet]
        [Authorize(Roles ="Admin,Doctor,Patient,Staff")]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetAll()
        {
            var notifications = await _notificationService.GetAllAsync();
            return Ok(notifications);
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Doctor,Patient,Staff")]
        public async Task<ActionResult<NotificationDto>> GetById(int id)
        {
            var notification = await _notificationService.GetByIdAsync(id);
            if (notification == null) return NotFound();
            return Ok(notification);
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<ActionResult<NotificationDto>> Create([FromBody] CreateNotificationDto dto)
        {
            var notification = await _notificationService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notification);
        }

        
        [HttpPut("markasread/{id}")]
        [Authorize(Roles = "Admin,Doctor,Patient,Staff")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var success = await _notificationService.MarkAsRead(id);
            if (!success) return NotFound();
            return NoContent();
        }

        // DELETE: api/notifications/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _notificationService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
