using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<PrescriptionMinimalDto> Prescriptions { get; set; } = new();
    }

    public class CreateMedicineDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateMedicineDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class MedicineMinimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
