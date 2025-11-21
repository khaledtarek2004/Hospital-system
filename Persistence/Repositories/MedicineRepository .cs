using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts.Repo;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class MedicineRepository : Repository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(HospitalDbContext context) : base(context) { }

        public async Task<IEnumerable<Medicine>> GetAllWithPrescriptionsAsync()
        {
            return await _context.Set<Medicine>()
                .Include(m => m.Prescriptions)
                    .ThenInclude(pr => pr.Patient)
                .ToListAsync();
        }
    }
}
