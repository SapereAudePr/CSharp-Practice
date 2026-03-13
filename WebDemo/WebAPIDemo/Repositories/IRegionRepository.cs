using WebAPIDemo.Models.Domain;

namespace WebAPIDemo.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
    }
}
