using Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_.IRepositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAll(string? filterOn, string? filterBy, string? sortOn, bool orderByAscending = false, int pageNumber = 1, int pageSize = 10);
        Task<Country?> GetById(int id);
        Task<Country> Create(Country country);
        Task<Country?> Update(Country country, int id);
        Task<Country> Delete(int id);
    }
}
