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
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
       public PatientRepository(HospitalDbContext context) : base(context) 
        { }
        public async Task<Patient?> GetPatientWithDetailsAsync(int id)
        {
            return await _context.Set<Patient>()
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.Doctor)
                .Include(p => p.MedicalRecords)
                .Include(p => p.prescriptions)
                    .ThenInclude(pr => pr.Medicines)
                .Include(p => p.invoices)
                    .ThenInclude(i => i.Payments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Patient> GetPatientByUserIdAsync(Guid applicationUserId)
        {
            return await _context.Patients
                                 .Include(p => p.ApplicationUser)
                                 .FirstOrDefaultAsync(p => p.ApplicationUserId == applicationUserId);
        }

    }

}
