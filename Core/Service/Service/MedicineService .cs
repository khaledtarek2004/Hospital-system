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
    public class MedicineService : IMedicineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MedicineDto?> GetByIdAsync(int id)
        {
            var medicine = await _unitOfWork.Medicines.GetByIdAsync(id);
            return medicine == null ? null : _mapper.Map<MedicineDto>(medicine);
        }

        public async Task<IEnumerable<MedicineDto>> GetAllAsync()
        {
            var meds = await _unitOfWork.Medicines.ListAllAsync();
            return _mapper.Map<IEnumerable<MedicineDto>>(meds);
        }

        public async Task<MedicineDto> CreateAsync(CreateMedicineDto dto)
        {
            var medicine = _mapper.Map<Medicine>(dto);

            await _unitOfWork.Medicines.AddAsync(medicine);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<MedicineDto>(medicine);
        }

        public async Task<MedicineDto?> UpdateAsync(int id, UpdateMedicineDto dto)
        {
            var medicine = await _unitOfWork.Medicines.GetByIdAsync(id);
            if (medicine == null) return null;

            _mapper.Map(dto, medicine);

            await _unitOfWork.Medicines.UpdateAsync(medicine);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<MedicineDto>(medicine);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var medicine = await _unitOfWork.Medicines.GetByIdAsync(id);
            if (medicine == null) return false;

            await _unitOfWork.Medicines.DeleteAsync(medicine);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }

}
