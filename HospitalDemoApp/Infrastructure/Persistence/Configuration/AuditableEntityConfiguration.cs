using Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public abstract class AuditableEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : AuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.CreationDate)
            .IsRequired();

        builder.Property(x => x.UpdateDate)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.UpdatedBy)
            .HasMaxLength(30)
            .IsRequired();
    }
}
