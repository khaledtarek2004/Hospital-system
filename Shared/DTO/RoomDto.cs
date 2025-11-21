using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public List<AppointmentMinimalDto> Appointments { get; set; } = new();
    }

    public class CreateRoomDto
    {
        public string RoomNumber { get; set; }
        public string Type { get; set; }
    }

    public class UpdateRoomDto
    {
        public string? RoomNumber { get; set; }
        public string? Type { get; set; }
    }

    public class RoomMinimalDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
    }

}
