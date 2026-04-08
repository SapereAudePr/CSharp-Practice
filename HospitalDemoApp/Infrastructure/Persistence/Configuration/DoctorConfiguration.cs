using Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class DoctorConfiguration : AuditableEntityConfiguration<Doctor>
{
    public override void Configure(EntityTypeBuilder<Doctor> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Specialization)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.LicenseNumber)
            .HasMaxLength(50)
            .IsRequired();
    }
}
