using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Models;
using Shared.DTO;

namespace Service
{
    public class HospitalMappingProfile : Profile
    {
        public HospitalMappingProfile()
        {
            
            // Patient
            CreateMap<Patient, PatientDto>();
            CreateMap<CreatePatientDto, Patient>();
            CreateMap<UpdatePatientDto, Patient>();

           
            // Doctor
            CreateMap<Doctor, DoctorDto>();
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<UpdateDoctorDto, Doctor>();

            
            // Department
            CreateMap<Department, DepartmentDto>();
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();

           
            // Appointment
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room.RoomNumber));

            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<UpdateAppointmentDto, Appointment>();

           
            // Medical Record
            CreateMap<MedicalRecord, MedicalRecordDto>();
            CreateMap<CreateMedicalRecordDto, MedicalRecord>();
            CreateMap<UpdateMedicalRecordDto, MedicalRecord>();

           
            // Medicine
            CreateMap<Medicine, MedicineDto>();
            CreateMap<CreateMedicineDto, Medicine>();
            CreateMap<UpdateMedicineDto, Medicine>();

            
            // Prescription
            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName));

            CreateMap<CreatePrescriptionDto, Prescription>();
            CreateMap<UpdatePrescriptionDto, Prescription>();

           
            // Invoice
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName));

            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<UpdateInvoiceDto, Invoice>();

            
            // Payment
            CreateMap<Payment, PaymentDto>();
            CreateMap<CreatePaymentDto, Payment>();

            
            // Room
            CreateMap<Room, RoomDto>();
            CreateMap<CreateRoomDto, Room>();
            CreateMap<UpdateRoomDto, Room>();

          
    
            // Notification
            CreateMap<Notification, NotificationDto>();
            CreateMap<CreateNotificationDto, Notification>();
        }
    }
}
