using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Data;
using WebAPIDemo.Models.Domain;

namespace WebAPIDemo.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly WebDemoDbContext _webDemoDbContext;

        public SQLWalkRepository(WebDemoDbContext webDemoDbContext)
        {
            this._webDemoDbContext = webDemoDbContext;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _webDemoDbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            var walkDomainModel = await _webDemoDbContext.Walks
                .Include("Difficulty").Include("Region")
                .FirstOrDefaultAsync(w => w.Id == id);

            if (walkDomainModel is null)
                return null;

            return walkDomainModel;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _webDemoDbContext.Walks.AddAsync(walk);
            await _webDemoDbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> UpdateAsync(Walk walk, Guid id)
        {
            var walkDomainModel = await _webDemoDbContext.Walks
                .FirstOrDefaultAsync(w => w.Id == id);

            if (walkDomainModel is null)
                return null;

            walkDomainModel.Name = walk.Name;
            walkDomainModel.Description = walk.Description;
            walkDomainModel.LengthInKm = walk.LengthInKm;
            walkDomainModel.WalkImgUrl = walk.WalkImgUrl;
            walkDomainModel.DifficultyId = walk.DifficultyId;
            walkDomainModel.RegionId = walk.RegionId;

            await _webDemoDbContext.SaveChangesAsync();

            return walkDomainModel;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walkDomainModel = await _webDemoDbContext.Walks
                .Include("Difficulty").Include("Region")
                .FirstAsync(w => w.Id == id);

            if (walkDomainModel is null)
                return null;

            _webDemoDbContext.Walks.Remove(walkDomainModel);
            await _webDemoDbContext.SaveChangesAsync();

            return walkDomainModel;
        }
    }
}
