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
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorDto?> GetByIdAsync(int id)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            return doctor == null ? null : _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            var doctors = await _unitOfWork.Doctors.ListAllAsync();
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }

        public async Task<DoctorDto> CreateAsync(CreateDoctorDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            await _unitOfWork.Doctors.AddAsync(doctor);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<DoctorDto?> UpdateAsync(int id, UpdateDoctorDto dto)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor == null) return null;

            _mapper.Map(dto, doctor);
            await _unitOfWork.Doctors.UpdateAsync(doctor);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor == null) return false;

            await _unitOfWork.Doctors.DeleteAsync(doctor);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}