using Domain.Mappings;
using Microsoft.AspNetCore.Mvc;
using Repositories_.IRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            string? filterOn, string? filterBy,
            string? sortOn, bool isAscending = false,
            int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterBy))
            {
                if (!filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase) && !filterOn.Equals("CountryId", StringComparison.OrdinalIgnoreCase))
                    return BadRequest("Only 'Name' or 'CountryId' is accepted for filterOn field.");
            }
            if (!string.IsNullOrEmpty(sortOn))
            {
                if (!sortOn.Equals("Name", StringComparison.OrdinalIgnoreCase) && !sortOn.Equals("CountryId", StringComparison.OrdinalIgnoreCase))
                    return BadRequest("Only 'Name' and 'CountryId' is accepted for sortOn field.");
            }

            if (pageNumber < 1 || pageSize < 1)
                return BadRequest("PageNumber and PageSize can't be lower than 1");

            var models = await cityRepository.GetAll(filterOn, filterBy, sortOn, isAscending, pageNumber, pageSize);
            if (models is null)
                return Problem(detail: "Could not found what you're looking for.", statusCode: StatusCodes.Status404NotFound, title: "Return All Failed!");

            return Ok(models.ListToDto());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var domainModel = await cityRepository.GetById(id);
            if (domainModel is null)
                return Problem(
                    detail: $"Could not found City with id: {id}",
                    instance: $"/City/{id}",
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Find Failed!");

            return Ok(domainModel.ToDto());
        }
    }
}
