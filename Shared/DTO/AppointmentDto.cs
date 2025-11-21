using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public int? RoomId { get; set; }
        public string RoomNumber { get; set; }
    }

    public class CreateAppointmentDto
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int? RoomId { get; set; }
    }

    public class UpdateAppointmentDto
    {
        public DateTime? Date { get; set; }
        public string? Status { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? RoomId { get; set; }
    }
    public class AppointmentMinimalDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }


}
