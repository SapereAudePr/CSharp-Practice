using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

internal class CorporateConfiguration : IEntityTypeConfiguration<Corporate>
{
    public void Configure(EntityTypeBuilder<Corporate> builder)
    {
        builder
            .HasMany(c => c.Employees)
            .WithOne(c => c.Corporate)
            .HasForeignKey(c => c.CorporateId);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Capacity)
            .IsRequired();


        builder.HasData(
            new Corporate { Id = 1, Name = "NyxTech", Capacity = 150 },
            new Corporate { Id = 2, Name = "NyxAudio", Capacity = 85 },
            new Corporate { Id = 3, Name = "NyxStudio", Capacity = 75 });
    }
}
