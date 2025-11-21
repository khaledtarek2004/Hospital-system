using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IPrescriptionService
    {
        Task<PrescriptionDto?> GetByIdAsync(int id);
        Task<IEnumerable<PrescriptionDto>> GetAllAsync();
        Task<PrescriptionDto> CreateAsync(CreatePrescriptionDto dto);
        Task<PrescriptionDto?> UpdateAsync(int id, UpdatePrescriptionDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
