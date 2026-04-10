using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class NurseConfiguration : AuditableEntityConfiguration<Nurse>
{
    public override void Configure(EntityTypeBuilder<Nurse> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.IsHeadNurse)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.CertificationLevel)
            .HasField("_certificationLevel")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.AssignedWard)
            .HasField("_assignedWard")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.ShiftType)
            .HasField("_shiftType")
            .HasMaxLength(30)
            .IsRequired();
    }
}
