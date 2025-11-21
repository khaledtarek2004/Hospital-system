using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IPatientService
    {
        Task<PatientDto?> GetByIdAsync(int id);
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<PatientDto> CreateAsync(CreatePatientDto dto);
        Task<PatientDto?> UpdateAsync(int id, UpdatePatientDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
