using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class HospitalDbContext : DbContext
{
    public HospitalDbContext(DbContextOptions options) : base(options)
    {
    }

}
