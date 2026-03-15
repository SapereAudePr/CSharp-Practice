using WebAPIDemo.Models.Domain;

namespace WebAPIDemo.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = false, int pageNumber = 1, int pageSize = 1000);
        Task<Walk> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Walk walk ,Guid id);
        Task<Walk> DeleteAsync(Guid id);
    }
}
