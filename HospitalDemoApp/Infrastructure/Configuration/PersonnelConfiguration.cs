using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class PersonnelConfiguration : AuditableEntityConfiguration<Personnel>
{
    public override void Configure(EntityTypeBuilder<Personnel> builder)
    {
        base.Configure(builder);

        builder.ToTable("Personnel");

        builder.HasDiscriminator<string>("PersonnelType")
            .HasValue<Doctor>("Doctor")
            .HasValue<Nurse>("Nurse")
            .HasValue<Technician>("Technician")
            .HasValue<Receptionist>("Receptionist")
            .HasValue<Janitor>("Janitor");


        builder.HasOne(x => x.Department)
            .WithMany(x => x.Personnel)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Property(x => x.Gender)
            .IsRequired();

        builder.OwnsOne(x => x.PhoneNumber, pn =>
        {
            pn.Property(x => x.Number)
            .HasMaxLength(20)
            .IsRequired();

            pn.Property(x => x.Label)
            .HasMaxLength(120)
            .IsRequired();
        });

        builder.OwnsOne(x => x.EmailAddress, ea =>
        {
            ea.Property(x => x.MailAddress)
            .HasMaxLength(254)
            .IsRequired();
        });
    }
}
