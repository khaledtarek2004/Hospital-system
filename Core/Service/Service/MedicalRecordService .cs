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
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicalRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MedicalRecordDto?> GetByIdAsync(int id)
        {
            var record = await _unitOfWork.MedicalRecords.GetByIdAsync(id);
            return record == null ? null : _mapper.Map<MedicalRecordDto>(record);
        }

        public async Task<IEnumerable<MedicalRecordDto>> GetAllAsync()
        {
            var records = await _unitOfWork.MedicalRecords.ListAllAsync();
            return _mapper.Map<IEnumerable<MedicalRecordDto>>(records);
        }

        public async Task<MedicalRecordDto> CreateAsync(CreateMedicalRecordDto dto)
        {
            var record = _mapper.Map<MedicalRecord>(dto);

            await _unitOfWork.MedicalRecords.AddAsync(record);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<MedicalRecordDto>(record);
        }

        public async Task<MedicalRecordDto?> UpdateAsync(int id, UpdateMedicalRecordDto dto)
        {
            var record = await _unitOfWork.MedicalRecords.GetByIdAsync(id);
            if (record == null) return null;

            _mapper.Map(dto, record);

            await _unitOfWork.MedicalRecords.UpdateAsync(record);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<MedicalRecordDto>(record);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var record = await _unitOfWork.MedicalRecords.GetByIdAsync(id);
            if (record == null) return false;

            await _unitOfWork.MedicalRecords.DeleteAsync(record);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }

}
