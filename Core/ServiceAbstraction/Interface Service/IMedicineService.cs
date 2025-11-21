using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IMedicineService
    {
        Task<MedicineDto?> GetByIdAsync(int id);
        Task<IEnumerable<MedicineDto>> GetAllAsync();
        Task<MedicineDto> CreateAsync(CreateMedicineDto dto);
        Task<MedicineDto?> UpdateAsync(int id, UpdateMedicineDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
