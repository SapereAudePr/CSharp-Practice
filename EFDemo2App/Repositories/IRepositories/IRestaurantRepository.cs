using Domain.Models.Domain;

namespace Repositories_.IRepositories;

public interface IRestaurantRepository
{
    Task<List<Restaurant>> GetAll(
        string? filterOn, string? filterBy,
        string? sortOn, bool isAscending = false,
        int pageNumber = 1, int pageSize = 10);
    Task<Restaurant?> GetById(int id);
    Task<Restaurant> Create(Restaurant city);
    Task<Restaurant?> Update(int id, Restaurant restaurant);
    Task<Restaurant?> Delete(int id);
}
