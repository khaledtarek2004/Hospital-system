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
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PatientDto?> GetByIdAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            return patient == null ? null : _mapper.Map<PatientDto>(patient);
        }

        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var patients = await _unitOfWork.Patients.ListAllAsync();
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }

        public async Task<PatientDto> CreateAsync(CreatePatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            await _unitOfWork.Patients.AddAsync(patient);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto?> UpdateAsync(int id, UpdatePatientDto dto)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null) return null;

            _mapper.Map(dto, patient);
            await _unitOfWork.Patients.UpdateAsync(patient);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null) return false;

            await _unitOfWork.Patients.DeleteAsync(patient);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
