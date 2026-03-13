using WebAPIDemo.Models.Domain;

namespace WebAPIDemo.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateRegionAsync(Region region);

        Task<Region> UpdateRegionAsync(Region region, Guid id);

        Task<Region> DeleteRegionAsync(Guid id);
    }
}
