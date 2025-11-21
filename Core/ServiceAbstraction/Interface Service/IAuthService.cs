using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO.AuthDTO;

namespace ServiceAbstraction.Interface_Service
{
    public interface IAuthService
    {
        Task<AuthenticationResponseDto> LoginAsync(LoginDto loginDto);
        Task<AuthenticationResponseDto> RegisterDoctorAsync(RegisterDoctorDto registerDoctorDto);
        Task<AuthenticationResponseDto> RegisterPatientAsync(RegisterPatientDto registerPatientDto);
        Task<AuthenticationResponseDto> RegisterStaffAsync(RegisterStaffDto registerStaffDto);
    }
}
