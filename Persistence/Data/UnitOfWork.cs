using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Contracts.Repo;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;

namespace Persistence.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalDbContext _context;
        private IPatientRepository _patientRepository;
        private IDoctorRepository _doctorRepository;
        private IAppointmentRepository _appointmentRepository;
        private IMedicalRecordRepository _medicalRecordRepository;
        private IPrescriptionRepository _prescriptionRepository;
        private IInvoiceRepository _invoiceRepository;
        private IPaymentRepository _paymentRepository;
        private IRoomRepository _roomRepository;
       
        private IDepartmentRepository _departmentRepository;
        private IMedicineRepository _medicineRepository;
        private INotificationRepository _notificationRepository;
        public UnitOfWork(HospitalDbContext context)
        {
            _context = context;
        }
        public IPatientRepository Patients =>_patientRepository ??= new PatientRepository(_context);
        public IDoctorRepository Doctors =>_doctorRepository ??= new DoctorRepository(_context);
        public IAppointmentRepository Appointments =>_appointmentRepository ??= new AppointmentRepository(_context);
        public IMedicalRecordRepository MedicalRecords =>_medicalRecordRepository ??= new MedicalRecordRepository(_context);
        public IPrescriptionRepository Prescriptions => _prescriptionRepository ??= new PrescriptionRepository(_context);
        public IInvoiceRepository Invoices => _invoiceRepository ??= new InvoiceRepository(_context);
        public IPaymentRepository Payments =>_paymentRepository ??= new PaymentRepository(_context);
        public IRoomRepository Rooms => _roomRepository ??= new RoomRepository(_context);
        public IDepartmentRepository Departments =>_departmentRepository ??= new DepartmentRepository(_context);
        public IMedicineRepository Medicines =>_medicineRepository ??= new MedicineRepository(_context);
        public INotificationRepository Notifications => _notificationRepository ??= new NotificationRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
