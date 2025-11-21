using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IRoomService
    {
        Task<RoomDto?> GetByIdAsync(int id);
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto> CreateAsync(CreateRoomDto dto);
        Task<RoomDto?> UpdateAsync(int id, UpdateRoomDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
