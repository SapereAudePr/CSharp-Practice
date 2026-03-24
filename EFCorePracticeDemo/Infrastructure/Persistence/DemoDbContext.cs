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



        modelBuilder.Entity<Corporate>().HasData(
            new Corporate { Id = 1, Name = "NyxTech", Capacity = 150 },
            new Corporate { Id = 2, Name = "NyxAudio", Capacity = 85},
            new Corporate { Id = 3, Name = "NyxStudio", Capacity = 75});

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, Name = "Alicia", LastName = "Fernandez"},
            new Person { Id = 2, Name = "Raven", LastName = "Smith"},
            new Person { Id = 3, Name = "Mike", LastName = "Stall"}
            );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Role = "Developer", PersonId = 1, CorporateId = 1 },
            new Employee { Id = 2, Role = "Manager", PersonId = 2, CorporateId = 2 },
            new Employee { Id = 3, Role = "Designer", PersonId = 3, CorporateId = 3 }
            );
    }
}
