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
    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(HospitalDbContext context) : base(context) { }

        public async Task<IEnumerable<Prescription>> GetAllWithMedicinesAsync()
        {
            return await _context.Set<Prescription>()
                .Include(p => p.Patient)
                .Include(p => p.Doctor)
                .Include(p => p.Medicines)
                .ToListAsync();
        }
    }
}
