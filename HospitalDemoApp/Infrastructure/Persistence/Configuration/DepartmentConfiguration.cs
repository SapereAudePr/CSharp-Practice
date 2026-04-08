using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class DepartmentConfiguration : AuditableEntityConfiguration<Department>
{
    public override void Configure(EntityTypeBuilder<Department> builder)
    {
        base.Configure(builder);

        builder.ToTable("Department");

        builder.HasIndex(d => new { d.Name, d.HospitalId })
            .IsUnique();

        builder.HasOne(x => x.Hospital)
            .WithMany(x => x.Departments)
            .HasForeignKey(x => x.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Personnel)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsMany(x => x.PhoneNumbers, pn =>
        {
            pn.ToTable("DepartmentPhoneNumbers");
            pn.WithOwner().HasForeignKey("DepartmentId");
            pn.Property<int>("Id");
            pn.HasKey("Id");
            pn.Property(p => p.Number)
            .IsRequired()
            .HasMaxLength(20);

            pn.Property(x => x.Label)
            .HasMaxLength(120)
            .IsRequired();
        });

        builder.OwnsMany(x => x.EmailAddresses, ea =>
        {
            ea.ToTable("DepartmentEmailAddresses");
            ea.WithOwner().HasForeignKey("DepartmentId");
            ea.Property<int>("Id");
            ea.HasKey("Id");
            ea.Property(x => x.MailAddress)
            .IsRequired()
            .HasMaxLength(254);
        });
    }
}
