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
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InvoiceDto?> GetByIdAsync(int id)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
            return invoice == null ? null : _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllAsync()
        {
            var invoices = await _unitOfWork.Invoices.ListAllAsync();
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<InvoiceDto> CreateAsync(CreateInvoiceDto dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);

            await _unitOfWork.Invoices.AddAsync(invoice);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<InvoiceDto?> UpdateAsync(int id, UpdateInvoiceDto dto)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
            if (invoice == null) return null;

            _mapper.Map(dto, invoice);

            await _unitOfWork.Invoices.UpdateAsync(invoice);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
            if (invoice == null) return false;

            await _unitOfWork.Invoices.DeleteAsync(invoice);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }

}
