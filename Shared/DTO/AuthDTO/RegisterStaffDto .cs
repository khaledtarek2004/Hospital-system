using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.AuthDTO
{
    public class RegisterStaffDto : RegisterDto
    {
        public string Role { get; set; }
    }
}
