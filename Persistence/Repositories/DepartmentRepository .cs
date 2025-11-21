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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HospitalDbContext context) : base(context) { }

        public async Task<Department?> GetDepartmentWithDoctorsAsync(int id)
        {
            return await _context.Set<Department>()
                .Include(d => d.Doctors)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
