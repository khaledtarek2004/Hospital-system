using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.FullName).IsRequired().HasMaxLength(150);
        builder.Property(d => d.Email).HasMaxLength(100);
        builder.Property(d => d.Specialty).HasMaxLength(100);


        builder.Property(d => d.Specialization)
           .IsRequired()
           .HasMaxLength(100);

        builder.Property(d => d.Qualifications)
            .HasMaxLength(200);

        builder.Property(d => d.ClinicAddress)
            .HasMaxLength(200);


        builder.HasIndex(d => d.ApplicationUserId).IsUnique();

        builder.HasOne(d => d.ApplicationUser)
               .WithOne()
               .HasForeignKey<Doctor>(d => d.ApplicationUserId)
               .OnDelete(DeleteBehavior.Cascade);




        builder.HasOne(d => d.Department)
               .WithMany(dep => dep.Doctors)
               .HasForeignKey(d => d.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Appointments)
               .WithOne(a => a.Doctor)
               .HasForeignKey(a => a.DoctorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Prescriptions)
               .WithOne(p => p.Doctor)
               .HasForeignKey(p => p.DoctorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}



