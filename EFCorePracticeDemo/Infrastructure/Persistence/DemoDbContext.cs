using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
    {

    }

    public DbSet<Corporate> Corporates { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relationships
        modelBuilder.Entity<Corporate>()
            .HasMany(c => c.Employees)
            .WithOne(c => c.Corporate)
            .HasForeignKey(c => c.CorporateId);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Person)
            .WithOne(e => e.Employee)
            .HasForeignKey<Employee>(e => e.PersonId)
            .IsRequired();


        // Properties
        modelBuilder.Entity<Corporate>(entity =>
        {
            entity.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entity.Property(x => x.Capacity).IsRequired();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(x => x.Role).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entity.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        });


        // Seeding
        modelBuilder.Entity<Corporate>().HasData(
            new Corporate { Id = 1, Name = "NyxTech", Capacity = 150 },
            new Corporate { Id = 2, Name = "NyxAudio", Capacity = 85 },
            new Corporate { Id = 3, Name = "NyxStudio", Capacity = 75 });

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Role = "Developer", PersonId = 1, CorporateId = 1 },
            new Employee { Id = 2, Role = "Manager", PersonId = 2, CorporateId = 2 },
            new Employee { Id = 3, Role = "Designer", PersonId = 3, CorporateId = 3 }
            );

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, Name = "Alicia", LastName = "Fernandez" },
            new Person { Id = 2, Name = "Raven", LastName = "Smith" },
            new Person { Id = 3, Name = "Mike", LastName = "Stall" }
            );

    }
}
