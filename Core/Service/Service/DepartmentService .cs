using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstraction.Interface_Service;
using Shared.DTO;

namespace Service.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var dep = await _unitOfWork.Departments.GetByIdAsync(id);
            return dep == null ? null : _mapper.Map<DepartmentDto>(dep);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var dep = await _unitOfWork.Departments.ListAllAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(dep);
        }

        public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto)
        {
            var dep = _mapper.Map<Department>(dto);
            await _unitOfWork.Departments.AddAsync(dep);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<DepartmentDto>(dep);
        }

        public async Task<DepartmentDto?> UpdateAsync(int id, UpdateDepartmentDto dto)
        {
            var dep = await _unitOfWork.Departments.GetByIdAsync(id);
            if (dep == null) return null;

            _mapper.Map(dto, dep);
            await _unitOfWork.Departments.UpdateAsync(dep);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<DepartmentDto>(dep);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dep = await _unitOfWork.Departments.GetByIdAsync(id);
            if (dep == null) return false;

            await _unitOfWork.Departments.DeleteAsync(dep);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
