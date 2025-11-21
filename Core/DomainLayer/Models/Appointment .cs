using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Appointment : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Status { get; set; } = null!;

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int? RoomId { get; set; }
        public Room? Room { get; set; }
    }

}
