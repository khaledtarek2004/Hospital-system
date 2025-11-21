using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IMedicalRecordService
    {
        Task<MedicalRecordDto?> GetByIdAsync(int id);
        Task<IEnumerable<MedicalRecordDto>> GetAllAsync();
        Task<MedicalRecordDto> CreateAsync(CreateMedicalRecordDto dto);
        Task<MedicalRecordDto?> UpdateAsync(int id, UpdateMedicalRecordDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
