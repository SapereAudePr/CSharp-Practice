using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence;

public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
    {

    }

    public DbSet<Corporate> Corporates { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Person> Persons { get; set; }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Manual registering

        //modelBuilder.ApplyConfiguration(new CorporateConfiguration());
        //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        //modelBuilder.ApplyConfiguration(new PersonConfiguration());

        // Automatically registers all configurations implementing : IEntityTypeConfiguration<T>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
