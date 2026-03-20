using Domain.Models.Domain;
using EFDemo.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Repositories_.IRepositories;

namespace Repositories_.Repositories;

public class SQLCityRepository : ICityRepository
{
    private readonly RestaurantDbContext dbContext;

    public SQLCityRepository(RestaurantDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<City>> GetAll(
        string? filterOn, string? filterBy,
        string? sortOn, bool isAscending = false,
        int pageNumber = 1, int pageSize = 10)
    {
        var query = dbContext.Cities.Include(x => x.Country).AsQueryable();

        if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterBy))
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(x => x.Name.Contains(filterBy));
            }
        }

        if (!string.IsNullOrEmpty(sortOn))
        {
            if (sortOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                query = isAscending ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);
            }
            if (sortOn.Equals("CountryId"))
            {
                query = isAscending ? query.OrderBy(x => x.CountryId) : query.OrderByDescending(x => x.CountryId);
            }
        }
        else
        {
            query = query.OrderByDescending(x => x.Id);
        }

        var skipped = (pageNumber - 1) * pageSize;

        return await query.Skip(skipped).Take(pageSize).ToListAsync();
    }

    public async Task<City?> GetById(int id)
    {
        var domainModel = await dbContext.Cities.Include(x => x.Country).FirstOrDefaultAsync(x => x.Id == id);
        if (domainModel is null)
            return null;
        return domainModel;
    }

    public async Task<City> Create(City city)
    {
        await dbContext.Cities.AddAsync(city);
        await dbContext.SaveChangesAsync();

        return city;
    }

    public async Task<City?> Update(int id, City city)
    {
        var domainModel = await dbContext.Cities.Include(x => x.Country).FirstOrDefaultAsync(x => x.Id == id);
        if (domainModel is null)
            return null;

        domainModel.Name = city.Name;
        domainModel.CountryId = city.CountryId;

        await dbContext.SaveChangesAsync();

        return domainModel;
    }

    public async Task<City?> Delete(int id)
    {
        var domainModel = await dbContext.Cities.FindAsync(id);
        if (domainModel is null)
            return null;

        dbContext.Remove(domainModel);
        await dbContext.SaveChangesAsync();

        return domainModel;
    }
}
