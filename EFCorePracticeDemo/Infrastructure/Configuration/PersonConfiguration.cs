using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

internal class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

        builder.HasData(
            new Person { Id = 1, Name = "Alicia", LastName = "Fernandez" },
            new Person { Id = 2, Name = "Raven", LastName = "Smith" },
            new Person { Id = 3, Name = "Mike", LastName = "Stall" }
            );
    }
}