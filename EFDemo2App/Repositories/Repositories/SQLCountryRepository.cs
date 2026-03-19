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

public class SQLCountryRepository : ICountry
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
        var country = dbContext.Countries.AsQueryable();

        if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterBy))
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                country = country.Where(x => x.Name.Contains(filterBy));
            }
        }

        if (!string.IsNullOrEmpty(sortOn))
        {
            country = orderByAscending ?
               country.OrderBy(x => x.Name) :
               country.OrderByDescending(x => x.Name);
        }

        var skipResults = (pageNumber - 1) * pageSize;

        return await country.Skip(skipResults).Take(pageSize).ToListAsync();
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

    public async Task<Country> Delete(int id)
    {
        var model = await dbContext.Countries.FindAsync(id);
        if (model is not null)
        {
            dbContext.Countries.Remove(model);
        }

        return model;
    }
}
