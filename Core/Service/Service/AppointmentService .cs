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
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppointmentDto?> GetByIdAsync(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
            return appointment == null ? null : _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            var appointments = await _unitOfWork.Appointments.ListAllAsync();
            return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        }

        public async Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);
            await _unitOfWork.Appointments.AddAsync(appointment);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<AppointmentDto?> UpdateAsync(int id, UpdateAppointmentDto dto)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
            if (appointment == null) return null;

            _mapper.Map(dto, appointment);
            await _unitOfWork.Appointments.UpdateAsync(appointment);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
            if (appointment == null) return false;

            await _unitOfWork.Appointments.DeleteAsync(appointment);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
