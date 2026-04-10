using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class JanitorConfiguration : AuditableEntityConfiguration<Janitor>
{
    public override void Configure(EntityTypeBuilder<Janitor> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.AssignedZone)
            .HasField("_assignedZone")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.BiohazardCertified)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.SecurityClearanceLevel)
            .HasField("_securityClearanceLevel")
            .HasMaxLength(50)
            .IsRequired();
    }
}
