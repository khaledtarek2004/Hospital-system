using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public List<MedicineMinimalDto> Medicines { get; set; }
    }

    public class CreatePrescriptionDto
    {
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public List<int> MedicineIds { get; set; } = new();
    }

    public class UpdatePrescriptionDto
    {
        public DateTime? Date { get; set; }
        public string? Notes { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
    }
    public class PrescriptionMinimalDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }

}
