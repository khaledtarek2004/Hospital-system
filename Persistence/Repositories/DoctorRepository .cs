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
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalDbContext context) : base(context) { }

       /* public async Task<Doctor?> GetDoctorWithDetailsAsync(int id)
        {
            return await _context.Set<Doctor>()
                .Include(d => d.Appointments)
                    .ThenInclude(a => a.Patient)
                .Include(d => d.Prescriptions)
                    .ThenInclude(pr => pr.Medicines)
                .Include(d => d.Department)
                .FirstOrDefaultAsync(d => d.Id == id);
        }*/
        public async Task<Doctor> GetDoctorByUserIdAsync(Guid applicationUserId)
        {
            return await _context.Doctors
                                 .Include(d => d.ApplicationUser)
                                 .FirstOrDefaultAsync(d => d.ApplicationUserId == applicationUserId);
        }

    }
}
