using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Data;
using WebAPIDemo.Models.Domain;

namespace WebAPIDemo.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly WebDemoDbContext _webDemoDbContext;

        public SQLRegionRepository(WebDemoDbContext webDemoDbContext)
        {
            
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _webDemoDbContext.Regions.ToListAsync();
        }
    }
}
