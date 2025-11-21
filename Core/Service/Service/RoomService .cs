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
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomDto?> GetByIdAsync(int id)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            return room == null ? null : _mapper.Map<RoomDto>(room);
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            var rooms = await _unitOfWork.Rooms.ListAllAsync();
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public async Task<RoomDto> CreateAsync(CreateRoomDto dto)
        {
            var room = _mapper.Map<Room>(dto);

            await _unitOfWork.Rooms.AddAsync(room);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<RoomDto>(room);
        }

        public async Task<RoomDto?> UpdateAsync(int id, UpdateRoomDto dto)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            if (room == null) return null;

            _mapper.Map(dto, room);

            await _unitOfWork.Rooms.UpdateAsync(room);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<RoomDto>(room);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            if (room == null) return false;

            await _unitOfWork.Rooms.DeleteAsync(room);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }

}
