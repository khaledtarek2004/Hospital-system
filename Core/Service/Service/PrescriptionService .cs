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
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrescriptionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PrescriptionDto?> GetByIdAsync(int id)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(id);
            return prescription == null ? null : _mapper.Map<PrescriptionDto>(prescription);
        }

        public async Task<IEnumerable<PrescriptionDto>> GetAllAsync()
        {
            var prescriptions = await _unitOfWork.Prescriptions.ListAllAsync();
            return _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
        }

        public async Task<PrescriptionDto> CreateAsync(CreatePrescriptionDto dto)
        {
            var prescription = _mapper.Map<Prescription>(dto);
            await _unitOfWork.Prescriptions.AddAsync(prescription);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PrescriptionDto>(prescription);
        }

        public async Task<PrescriptionDto?> UpdateAsync(int id, UpdatePrescriptionDto dto)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(id);
            if (prescription == null) return null;

            _mapper.Map(dto, prescription);
            await _unitOfWork.Prescriptions.UpdateAsync(prescription);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PrescriptionDto>(prescription);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(id);
            if (prescription == null) return false;

            await _unitOfWork.Prescriptions.DeleteAsync(prescription);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
