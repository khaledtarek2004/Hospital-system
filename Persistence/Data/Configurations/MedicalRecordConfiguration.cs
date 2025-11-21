using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
{
    public void Configure(EntityTypeBuilder<MedicalRecord> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Description).HasMaxLength(500);

        builder.HasOne(m => m.Patient)
               .WithMany(p => p.MedicalRecords)
               .HasForeignKey(m => m.PatientId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}



