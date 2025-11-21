using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.Contracts.Repo
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        //Task<Doctor?> GetDoctorWithDetailsAsync(int id);

        Task<Doctor> GetDoctorByUserIdAsync(Guid applicationUserId);
    }
}
