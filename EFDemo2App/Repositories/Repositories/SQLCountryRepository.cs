using Domain.Models.Domain;
using EFDemo.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Repositories_.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_.Repositories;

public class SQLCountryRepository : ICountryRepository
{
    private readonly RestaurantDbContext dbContext;

    public SQLCountryRepository(RestaurantDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Country>> GetAll(string? filterOn, string? filterBy,
        string? sortOn, bool orderByAscending = false,
        int pageNumber = 1, int pageSize = 10)
    {
        var query = dbContext.Countries.AsQueryable();

        if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterBy))
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(x => x.Name.Contains(filterBy));
            }
        }

        if (!string.IsNullOrEmpty(sortOn))
        {
            if (sortOn.Equals("Name"))
            {
                query = orderByAscending ?
               query.OrderBy(x => x.Name) :
               query.OrderByDescending(x => x.Name);
            }
        }
        else
        {
            query = query.OrderBy(x => x.Id);
        }

        var skipResults = (pageNumber - 1) * pageSize;

        return await query.Skip(skipResults).Take(pageSize).ToListAsync();
    }

    public async Task<Country?> GetById(int id) => await dbContext.Countries.FindAsync(id);

    public async Task<Country> Create(Country country)
    {
        await dbContext.Countries.AddAsync(country);
        await dbContext.SaveChangesAsync();

        return country;
    }
    public async Task<Country?> Update(Country country, int id)
    {
        var domainModel = await dbContext.Countries.FindAsync(id);

        if (domainModel is null)
            return null;

        domainModel.Name = country.Name;

        await dbContext.SaveChangesAsync();

        return domainModel;
    }

    public async Task<Country?> Delete(int id)
    {
        var model = await dbContext.Countries.FindAsync(id);
        if (model is null)
            return null;

        dbContext.Countries.Remove(model);
        await dbContext.SaveChangesAsync();

        return model;
    }
}
