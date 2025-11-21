using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.FullName).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Email).HasMaxLength(100);



        builder.HasIndex(p => p.ApplicationUserId).IsUnique();

        builder.HasOne(p => p.ApplicationUser)
               .WithOne()
               .HasForeignKey<Patient>(p => p.ApplicationUserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.Gender)
               .HasMaxLength(20);

        builder.Property(p => p.Address)
               .HasMaxLength(200);

        builder.Property(p => p.ContactNumber)
               .HasMaxLength(50);



        builder.HasMany(p => p.Appointments)
               .WithOne(a => a.Patient)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.MedicalRecords)
               .WithOne(m => m.Patient)
               .HasForeignKey(m => m.PatientId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}



