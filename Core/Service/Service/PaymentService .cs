using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Service.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaymentDto?> GetByIdAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            return payment == null ? null : _mapper.Map<PaymentDto>(payment);
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var payments = await _unitOfWork.Payments.ListAllAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto> CreateAsync(CreatePaymentDto dto)
        {
            var payment = _mapper.Map<Payment>(dto);

            await _unitOfWork.Payments.AddAsync(payment);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<PaymentDto?> UpdateAsync(int id, UpdatePaymentDto dto)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment == null) return null;

            _mapper.Map(dto, payment);

            await _unitOfWork.Payments.UpdateAsync(payment);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment == null) return false;

            await _unitOfWork.Payments.DeleteAsync(payment);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }

}
