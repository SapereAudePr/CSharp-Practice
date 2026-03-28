using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasOne(e => e.Person)
            .WithOne(e => e.Employee)
            .HasForeignKey<Employee>(e => e.PersonId)
            .IsRequired();


        builder.Property(x => x.Role).IsRequired().HasMaxLength(50);

        builder.HasData(
            new Employee { Id = 1, Role = "Developer", PersonId = 1, CorporateId = 1 },
            new Employee { Id = 2, Role = "Manager", PersonId = 2, CorporateId = 2 },
            new Employee { Id = 3, Role = "Designer", PersonId = 3, CorporateId = 3 }
            );
    }
}
