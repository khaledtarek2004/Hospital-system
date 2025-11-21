using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IDoctorService
    {
        Task<DoctorDto?> GetByIdAsync(int id);
        Task<IEnumerable<DoctorDto>> GetAllAsync();
        Task<DoctorDto> CreateAsync(CreateDoctorDto dto);
        Task<DoctorDto?> UpdateAsync(int id, UpdateDoctorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
