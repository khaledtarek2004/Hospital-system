using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interface_Service;
using Shared.DTO.AuthDTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("RegisterDoctor")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorDto registerDoctorDto)
        {
            var result = await _authService.RegisterDoctorAsync(registerDoctorDto);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

      
        [HttpPost("RegisterPatient")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientDto registerPatientDto)
        {
            var result = await _authService.RegisterPatientAsync(registerPatientDto);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

      
        [HttpPost("RegisterStaff")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterStaff([FromBody] RegisterStaffDto registerStaffDto)
        {
            var result = await _authService.RegisterStaffAsync(registerStaffDto);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
