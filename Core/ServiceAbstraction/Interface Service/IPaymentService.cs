using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IPaymentService
    {
        Task<PaymentDto?> GetByIdAsync(int id);
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<PaymentDto> CreateAsync(CreatePaymentDto dto);
        Task<PaymentDto?> UpdateAsync(int id, UpdatePaymentDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
