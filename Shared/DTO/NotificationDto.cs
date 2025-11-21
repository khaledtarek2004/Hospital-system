using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        
    }

    public class CreateNotificationDto
    {
        public string Message { get; set; }
        public int? UserId { get; set; }
    }

    public class UpdateNotificationDto
    {
        public string? Message { get; set; }
        public bool? IsRead { get; set; }
        public int? UserId { get; set; }
    }

    public class NotificationMinimalDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }

}
