using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<AppointmentDto> Appointments { get; set; } = new();
        public List<MedicalRecordDto> MedicalRecords { get; set; } = new();
    }

    public class CreatePatientDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class UpdatePatientDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public class PatientMinimalDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

}
