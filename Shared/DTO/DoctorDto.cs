using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }
        public DepartmentDto Department { get; set; }
        public List<AppointmentDto> Appointments { get; set; } = new();
        public List<PrescriptionDto> Prescriptions { get; set; } = new();
    }

    public class CreateDoctorDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }
        public int DepartmentId { get; set; }
    }

    public class UpdateDoctorDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Specialty { get; set; }
        public int? DepartmentId { get; set; }
    }

    public class DoctorMinimalDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

}
