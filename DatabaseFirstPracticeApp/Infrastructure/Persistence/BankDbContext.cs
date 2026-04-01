using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BankChurn> BankChurn { get; set; }

    }
}
