using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IAppointmentService
    {
        Task<AppointmentDto?> GetByIdAsync(int id);
        Task<IEnumerable<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto);
        Task<AppointmentDto?> UpdateAsync(int id, UpdateAppointmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
