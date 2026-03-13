using Microsoft.AspNetCore.Http.HttpResults;
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
            this._webDemoDbContext = webDemoDbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _webDemoDbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _webDemoDbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            await _webDemoDbContext.Regions.AddAsync(region);
            await _webDemoDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateRegionAsync(Region region, Guid id)
        {
            Region? regionDomainModel = await _webDemoDbContext.Regions.
                FirstOrDefaultAsync(r => r.Id == id);

            if (regionDomainModel is null)
                return null;

            regionDomainModel.Code = region.Code;
            regionDomainModel.Name = region.Name;
            regionDomainModel.RegionImgUrl = region.RegionImgUrl;

            await _webDemoDbContext.SaveChangesAsync();

            return regionDomainModel;
        }

        public async Task<Region> DeleteRegionAsync(Guid id)
        {
            var regionDomainModel = await _webDemoDbContext.Regions.
                FirstOrDefaultAsync(r => r.Id == id);

            _webDemoDbContext.Regions.Remove(regionDomainModel);
            await _webDemoDbContext.SaveChangesAsync();

            return regionDomainModel;
        }
    }
}
