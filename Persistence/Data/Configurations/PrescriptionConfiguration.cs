using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Notes).HasMaxLength(500);

        builder.HasOne(p => p.Patient)
               .WithMany(pat => pat.prescriptions)
               .HasForeignKey(p => p.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Doctor)
               .WithMany(d => d.Prescriptions)
               .HasForeignKey(p => p.DoctorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}



