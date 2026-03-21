using Domain.Models.Domain;

namespace Repositories_.IRepositories;

public interface IRegionRepository
{
    public Task<List<Region>> GetAll(
        string? filterOn, string? filterBy,
        string? sortOn, bool isAscending = false,
        int pageNumber = 1, int pageSize = 10);

    public Task<Region?> GetById(int id);
    public Task<Region?> Create(Region region);
    public Task<Region?> Update(int id, Region region);
    public Task<Region?> Delete(int id);
}
