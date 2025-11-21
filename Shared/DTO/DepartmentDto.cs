using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DoctorMinimalDto> Doctors { get; set; } = new();
    }

    public class CreateDepartmentDto
    {
        public string Name { get; set; }
    }

    public class UpdateDepartmentDto
    {
        public string? Name { get; set; }
    }

    public class DepartmentMinimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
