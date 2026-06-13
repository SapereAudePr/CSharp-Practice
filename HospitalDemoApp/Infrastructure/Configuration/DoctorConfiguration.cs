using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
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
