using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.TotalAmount).IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(i => i.Date).IsRequired();

        builder.HasOne(i => i.Patient)
               .WithMany(p => p.invoices)
               .HasForeignKey(i => i.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(i => i.Payments)
               .WithOne(p => p.Invoice)
               .HasForeignKey(p => p.InvoiceId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}



