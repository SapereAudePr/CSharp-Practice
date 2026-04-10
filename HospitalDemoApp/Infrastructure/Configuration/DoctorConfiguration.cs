using Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class DoctorConfiguration : AuditableEntityConfiguration<Doctor>
{
    public override void Configure(EntityTypeBuilder<Doctor> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Specialization)
            .HasField("_specialization")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.LicenseNumber)
            .HasField("_licenseNumber")
            .HasMaxLength(50)
            .IsRequired();
    }
}
