using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IInvoiceService
    {
        Task<InvoiceDto?> GetByIdAsync(int id);
        Task<IEnumerable<InvoiceDto>> GetAllAsync();
        Task<InvoiceDto> CreateAsync(CreateInvoiceDto dto);
        Task<InvoiceDto?> UpdateAsync(int id, UpdateInvoiceDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
