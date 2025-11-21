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
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<NotificationDto?> GetByIdAsync(int id)
        {
            var notif = await _unitOfWork.Notifications.GetByIdAsync(id);
            return notif == null ? null : _mapper.Map<NotificationDto>(notif);
        }

        public async Task<IEnumerable<NotificationDto>> GetAllAsync()
        {
            var notif = await _unitOfWork.Notifications.ListAllAsync();
            return _mapper.Map<IEnumerable<NotificationDto>>(notif);
        }

        public async Task<NotificationDto> CreateAsync(CreateNotificationDto dto)
        {
            var notif = _mapper.Map<Notification>(dto);

            await _unitOfWork.Notifications.AddAsync(notif);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<NotificationDto>(notif);
        }

        public async Task<bool> MarkAsRead(int id)
        {
            var notif = await _unitOfWork.Notifications.GetByIdAsync(id);
            if (notif == null) return false;

            notif.IsRead = true;
            notif.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.Notifications.UpdateAsync(notif);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var notif = await _unitOfWork.Notifications.GetByIdAsync(id);
            if (notif == null) return false;

            await _unitOfWork.Notifications.DeleteAsync(notif);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }

}
