using Domain.Models.Domain;

namespace Repositories_.IRepositories;

public interface ICityRepository
{
    Task<List<City>> GetAll(
        string? filterOn, string? filterBy, 
        string? sortOn, bool isAscending = false, 
        int pageNumber = 1, int pageSize = 10);
    Task<City?> GetById(int id);
    Task<City> Create(City city);
    Task<City?> Update(int id, City city);
    Task<City?> Delete(int id);
}
