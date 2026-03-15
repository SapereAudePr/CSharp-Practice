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
        public async Task<List<Walk>> GetAllAsync(
            string? filterOn = null, 
            string? filterQuery = null, 
            string? sortBy = null, 
            bool isAscending = false,
            int pageNumber = 1,
            int pageSize = 1000)
        {
            var walks = _webDemoDbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                filterQuery = filterQuery.ToLower();
                switch (filterOn)
                {
                    case "Name":
                        walks = walks.Where(x => x.Name.Contains(filterQuery));
                        break;

                    case "Description":
                        walks = walks.Where(x => x.Description.Contains(filterQuery));
                        break;

                    case "LengthInKm":
                        if (double.TryParse(filterQuery, out var length))
                            walks = walks.Where(x => x.LengthInKm == length);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "Name":
                        walks = walks = isAscending ?
                            walks.OrderBy(x => x.Name) :
                            walks.OrderByDescending(x => x.Name);
                        break;
                    case "LengthInKm":
                        walks = walks = isAscending ?
                        walks.OrderBy(x => x.LengthInKm) :
                        walks.OrderByDescending(x => x.LengthInKm);
                        break;
                }
            }

            var skipResults = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
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
