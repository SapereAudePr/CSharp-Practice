using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Models.Domain;

namespace WebAPIDemo.Data
{
    public class WebDemoDbContext : DbContext
    {
        public WebDemoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("927cf7bc-5249-4de7-a1a4-5fce13792125"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("1f2f1f77-25ce-450d-927c-4bc87d01b4b8"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("7d98406f-6b1e-4d9d-9442-083581e73883"),
                    Name = "Hard"
                }
            };

            // Seed difficulties to the db
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("c812ca2d-dbf2-45d1-9143-1a9b7932f615"),
                    Code = "NTL",
                    Name = "Northland"
                },
                new Region()
                {
                    Id = Guid.Parse("822940ae-6e22-4a1a-9e43-f79586eea451"),
                    Code = "AUK",
                    Name = "Auckland"
                },
                new Region()
                {
                    Id = Guid.Parse("2cc22ad3-f286-464f-a60f-a0e4897c40dd"),
                    Code = "TKI",
                    Name = "Taranaki"
                }
            };

            // Seed data for Regions
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
