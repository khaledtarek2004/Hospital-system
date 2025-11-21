using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class MedicalRecordDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public PatientMinimalDto Patient { get; set; }
    }

    public class CreateMedicalRecordDto
    {
        public string Description { get; set; }
        public int PatientId { get; set; }
    }

    public class UpdateMedicalRecordDto
    {
        public string? Description { get; set; }
        public int? PatientId { get; set; }
    }

    public class MedicalRecordMinimalDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

}
