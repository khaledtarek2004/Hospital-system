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
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(HospitalDbContext context) : base(context) { }

        public async Task<Invoice?> GetInvoiceWithPaymentsAsync(int id)
        {
            return await _context.Set<Invoice>()
                .Include(i => i.Patient)
                .Include(i => i.Payments)
                .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
