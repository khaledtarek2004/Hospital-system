using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IDepartmentService
    {
        Task<DepartmentDto?> GetByIdAsync(int id);
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto);
        Task<DepartmentDto?> UpdateAsync(int id, UpdateDepartmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
