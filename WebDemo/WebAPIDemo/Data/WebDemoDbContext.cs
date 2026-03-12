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

    }
}
