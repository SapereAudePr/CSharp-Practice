using EFDemo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.Data.DatabaseContext;

public class RestaurantDbContext : DbContext
{
    public RestaurantDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>()
            .Property(c => c.CreationTime)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<City>()
            .Property(c => c.CreationTime)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Region>()
            .Property(c => c.CreationTime)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Restaurant>()
            .Property(c => c.CreationTime)
            .HasDefaultValueSql("GETUTCDATE()");


        // Seed
        var seedTime = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);

        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Name = "Ireland", CreationTime = seedTime },
            new Country { Id = 2, Name = "Turkey", CreationTime = seedTime },
            new Country { Id = 3, Name = "Germany", CreationTime = seedTime }
        );
        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "Ankara", CountryId = 2, CreationTime = seedTime },
            new City { Id = 2, Name = "Berlin", CountryId = 3, CreationTime = seedTime },
            new City { Id = 3, Name = "Dublin", CountryId = 1, CreationTime = seedTime }
        );
        modelBuilder.Entity<Region>().HasData(
            new Region { Id = 1, Name = "Cankaya", CityId = 1, CreationTime = seedTime },
            new Region { Id = 2, Name = "Mitte", CityId = 2, CreationTime = seedTime },
            new Region { Id = 3, Name = "Temple Bar", CityId = 3, CreationTime = seedTime }
        );
    }
}
