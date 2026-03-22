using Domain.Models.Domain;
using EFDemo.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Repositories_.IRepositories;

namespace Repositories_.Repositories;

public class SQLRestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantDbContext dbContext;

    public SQLRestaurantRepository(RestaurantDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Restaurant>> GetAll(
        string? filterOn, string? filterBy,
        string? sortOn, bool isAscending = false,
        int pageNumber = 1, int pageSize = 10)
    {
        var models = dbContext.Restaurants.Include(x => x.Region).AsQueryable();

        if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterBy))
        {
            if (filterOn.Equals("Name"))
            {
                models = models.Where(x => x.Name.Contains(filterBy));
            }
        }

        if (!string.IsNullOrEmpty(sortOn))
        {
            models = sortOn switch
            {
                "Capacity" => isAscending ?
                models.OrderBy(x => x.Capacity) :
                models.OrderByDescending(x => x.Capacity),

                "ReviewPoint" => isAscending ?
                models.OrderBy(x => x.ReviewPoint) :
                models.OrderByDescending(x => x.ReviewPoint),

                "StartShiftTime" => isAscending ?
                models.OrderBy(x => x.StartShiftTime) :
                models.OrderByDescending(x => x.StartShiftTime),

                "EndShiftTime" => isAscending ?
                models.OrderBy(x => x.EndShiftTime) :
                models.OrderByDescending(x => x.EndShiftTime),

                "BuiltDate" => isAscending ?
                models.OrderBy(x => x.BuiltDate) :
                models.OrderByDescending(x => x.BuiltDate),

                _ => models.OrderBy(x => x.Id)
            };
        }
        else
        {
            models = models.OrderBy(x => x.Id);
        }

        pageNumber = pageNumber < 1 ? pageNumber = 1 : pageNumber;
        pageSize = pageSize < 1 ? pageSize = 10 : pageSize;
        var skipped = (pageNumber - 1) * pageSize;

        return await models.Skip(skipped).Take(pageSize).ToListAsync();
    }

    public async Task<Restaurant?> GetById(int id)
    {
        var domainModel = await dbContext.Restaurants
            .Include(x => x.Region)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (domainModel is null)
            return null;

        return domainModel;
    }

    public async Task<Restaurant> Create(Restaurant restaurant)
    {
        await dbContext.AddAsync(restaurant);
        await dbContext.SaveChangesAsync();

        return restaurant;
    }

    public async Task<Restaurant?> Update(int id, Restaurant restaurant)
    {
        var domainModel = await dbContext.Restaurants.FindAsync(id);
        if (domainModel is null)
            return null;

        domainModel.Name = restaurant.Name;
        domainModel.Capacity = restaurant.Capacity;
        domainModel.ReviewPoint = restaurant.ReviewPoint;
        domainModel.StartShiftTime = restaurant.StartShiftTime;
        domainModel.EndShiftTime = restaurant.EndShiftTime;
        domainModel.BuiltDate = restaurant.BuiltDate;
        domainModel.RegionId = restaurant.RegionId;

        await dbContext.SaveChangesAsync();

        return domainModel;
    }

    public async Task<Restaurant?> Delete(int id)
    {
        var domainModel = await dbContext.Restaurants.FindAsync(id);
        if (domainModel is null)
            return null;

        dbContext.Restaurants.Remove(domainModel);
        await dbContext.SaveChangesAsync();

        return domainModel;
    }
}
