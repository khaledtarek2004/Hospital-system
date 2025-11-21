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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(HospitalDbContext context) : base(context) { }

        public async Task<IEnumerable<Room>> GetAllWithAppointmentsAsync()
        {
            return await _context.Set<Room>()
                .Include(r => r.Appointments)
                    .ThenInclude(a => a.Patient)
                .ToListAsync();
        }
    }
}
