using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts.Repo;
using DomainLayer.Models;

namespace DomainLayer.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patients { get; }
        IDoctorRepository Doctors { get; }
        IAppointmentRepository Appointments { get; }
        IMedicalRecordRepository MedicalRecords { get; }
        IPrescriptionRepository Prescriptions { get; }
        IInvoiceRepository Invoices { get; }
        IPaymentRepository Payments { get; }
        IRoomRepository Rooms { get; }
        IDepartmentRepository Departments { get; }
        IMedicineRepository Medicines { get; }
        INotificationRepository Notifications { get; }

        Task<int> CommitAsync();
    }
}
