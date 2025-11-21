using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction.Interface_Service;
using Shared.DTO.AuthDTO;

namespace Service.Service
{
    public class AuthService : IAuthService
    {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<IdentityRole<Guid>> _roleManager;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IConfiguration _configuration;

            public AuthService(
                UserManager<User> userManager,
                RoleManager<IdentityRole<Guid>> roleManager,
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IConfiguration configuration)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _configuration = configuration;
            }

            public async Task<AuthenticationResponseDto> LoginAsync(LoginDto loginDto)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                {
                    return new AuthenticationResponseDto
                    {
                        Success = false,
                        Message = "Invalid credentials"
                    };
                }

                var token = await GenerateJwtToken(user);

                return new AuthenticationResponseDto
                {
                    Success = true,
                    Message = "Login successful",
                    Token = token
                };
            }

            public async Task<AuthenticationResponseDto> RegisterDoctorAsync(RegisterDoctorDto registerDoctorDto)
            {
                var user = new User
                {
                    Email = registerDoctorDto.Email,
                    UserName = registerDoctorDto.Email,
                    FirstName = registerDoctorDto.FirstName,
                    LastName = registerDoctorDto.LastName
                };

                var result = await _userManager.CreateAsync(user, registerDoctorDto.Password);
                if (!result.Succeeded)
                {
                    return new AuthenticationResponseDto
                    {
                        Success = false,
                        Message = string.Join(",", result.Errors.Select(e => e.Description))
                    };
                }

                if (!await _roleManager.RoleExistsAsync("Doctor"))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>("Doctor"));
                }
                await _userManager.AddToRoleAsync(user, "Doctor");

                var doctor = new Doctor
                {
                    ApplicationUserId = user.Id,
                    Specialization = registerDoctorDto.Specialization,
                    Qualifications = registerDoctorDto.Qualifications,
                    YearsOfExperience = registerDoctorDto.YearsOfExperience,
                    ClinicAddress = registerDoctorDto.ClinicAddress
                };

                await _unitOfWork.Doctors.AddAsync(doctor);
                await _unitOfWork.CommitAsync();

                return new AuthenticationResponseDto
                {
                    Success = true,
                    Message = "Doctor registered successfully"
                };
            }

            public async Task<AuthenticationResponseDto> RegisterPatientAsync(RegisterPatientDto registerPatientDto)
            {
                var user = new User
                {
                    Email = registerPatientDto.Email,
                    UserName = registerPatientDto.Email,
                    FirstName = registerPatientDto.FirstName,
                    LastName = registerPatientDto.LastName
                };

                var result = await _userManager.CreateAsync(user, registerPatientDto.Password);
                if (!result.Succeeded)
                {
                    return new AuthenticationResponseDto
                    {
                        Success = false,
                        Message = string.Join(",", result.Errors.Select(e => e.Description))
                    };
                }

                if (!await _roleManager.RoleExistsAsync("Patient"))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>("Patient"));
                }
                await _userManager.AddToRoleAsync(user, "Patient");

                var patient = new Patient
                {
                    ApplicationUserId = user.Id,
                    Gender = registerPatientDto.Gender,
                    Address = registerPatientDto.Address,
                    ContactNumber = registerPatientDto.ContactNumber,
                    InsuranceDetails = registerPatientDto.InsuranceDetails,
                    EmergencyContact = registerPatientDto.EmergencyContact
                };

                await _unitOfWork.Patients.AddAsync(patient);
                await _unitOfWork.CommitAsync();

                return new AuthenticationResponseDto
                {
                    Success = true,
                    Message = "Patient registered successfully"
                };
            }

            public async Task<AuthenticationResponseDto> RegisterStaffAsync(RegisterStaffDto registerStaffDto)
            {
                var user = new User
                {
                    Email = registerStaffDto.Email,
                    UserName = registerStaffDto.Email,
                    FirstName = registerStaffDto.FirstName,
                    LastName = registerStaffDto.LastName
                };

                var result = await _userManager.CreateAsync(user, registerStaffDto.Password);
                if (!result.Succeeded)
                {
                    return new AuthenticationResponseDto
                    {
                        Success = false,
                        Message = string.Join(",", result.Errors.Select(e => e.Description))
                    };
                }

                if (!await _roleManager.RoleExistsAsync(registerStaffDto.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(registerStaffDto.Role));
                }
                await _userManager.AddToRoleAsync(user, registerStaffDto.Role);

                return new AuthenticationResponseDto
                {
                    Success = true,
                    Message = "Staff registered successfully"
                };
            }

            private async Task<string> GenerateJwtToken(User user)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"])),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }

