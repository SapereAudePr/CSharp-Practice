using Domain.Models.Domain;
using EFDemo.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Repositories_.IRepositories;

namespace Repositories_.Repositories;

public class SQLRegionRepository : IRegionRepository
{
    private readonly RestaurantDbContext dbContext;

    public SQLRegionRepository(RestaurantDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Region>> GetAll(
        string? filterOn, string? filterBy,
        string? sortOn, bool isAscending = false,
        int pageNumber = 1, int pageSize = 10)
    {
        var query = dbContext.Regions.Include(x => x.City).AsQueryable();

        if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterBy))
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(x => x.Name.Equals(filterBy));
            }
        }

        if (!string.IsNullOrEmpty(sortOn))
        {
            if (sortOn.Equals("CityId", StringComparison.OrdinalIgnoreCase))
            {
                query = isAscending ? query.OrderBy(x => x.CityId) : query.OrderByDescending(x => x.CityId);
            }

            if (sortOn.Equals("Id", StringComparison.OrdinalIgnoreCase))
            {
                query = isAscending ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
            }
        }
        else
        {
            query = query.OrderBy(x => x.Id);
        }

        var skipped = (pageNumber - 1) * pageSize;

        return await query.Skip(skipped).Take(pageSize).ToListAsync();
    }

    public async Task<Region?> GetById(int id)
    {
        var domainModel = await dbContext.Regions.Include(x => x.City).FirstOrDefaultAsync(x => x.Id == id);
        if (domainModel is null)
            return null;

        return domainModel;
    }

    public async Task<Region?> Create(Region region)
    {
        var domainModel = new Region()
        {
            Name = region.Name,
            CityId = region.CityId
        };

        await dbContext.AddAsync(domainModel);
        await dbContext.SaveChangesAsync();

        return domainModel;
    }

    public async Task<Region?> Update(int id, Region region)
    {
        var domainModel = await dbContext.Regions.FindAsync(id);
        if (domainModel is null)
            return null;

        domainModel.Name = region.Name;
        domainModel.CityId = region.CityId;

        await dbContext.SaveChangesAsync();

        return domainModel;
    }

    public async Task<Region?> Delete(int id)
    {
        var domainModel = await dbContext.Regions.FindAsync(id);
        if (domainModel is null)
            return null;

        dbContext.Remove(domainModel);
        await dbContext.SaveChangesAsync();

        return domainModel;
    }
}
