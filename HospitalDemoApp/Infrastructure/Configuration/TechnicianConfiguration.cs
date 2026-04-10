using Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class TechnicianConfiguration : AuditableEntityConfiguration<Technician>
{
    public override void Configure(EntityTypeBuilder<Technician> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.TechnicalCategory)
            .HasField("_technicalCategory")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.EquipmentSpecialty)
            .HasField("_equipmentSpecialty")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.CertificationNumber)
            .HasField("_certificationNumber")
            .HasMaxLength(80)
            .IsRequired();
    }
}
