using WebAPIDemo.Models.Domain;

namespace WebAPIDemo.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = false);
        Task<Walk> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Walk walk ,Guid id);
        Task<Walk> DeleteAsync(Guid id);
    }
}
