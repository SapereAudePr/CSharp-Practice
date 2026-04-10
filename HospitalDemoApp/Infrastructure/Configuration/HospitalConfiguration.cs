using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class HospitalConfiguration : AuditableEntityConfiguration<Hospital>
{
    public override void Configure(EntityTypeBuilder<Hospital> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Hospital");

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.HasMany(x => x.Departments)
            .WithOne(x => x.Hospital)
            .HasForeignKey(x => x.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(h => h.Address)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.BuiltDate)
            .IsRequired();

        builder.Property(h => h.MainEmailAddress)
            .IsRequired()
            .HasMaxLength(254);

        builder.HasIndex(h => h.MainEmailAddress)
            .IsUnique();

        builder.Property(h => h.MainPhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(h => h.MainPhoneNumber)
            .IsUnique();
    }
}
