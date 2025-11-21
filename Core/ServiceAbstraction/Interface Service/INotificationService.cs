using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface INotificationService
    {
        Task<NotificationDto?> GetByIdAsync(int id);
        Task<IEnumerable<NotificationDto>> GetAllAsync();
        Task<NotificationDto> CreateAsync(CreateNotificationDto dto);
        Task<bool> MarkAsRead(int id);
        Task<bool> DeleteAsync(int id);
    }

}
