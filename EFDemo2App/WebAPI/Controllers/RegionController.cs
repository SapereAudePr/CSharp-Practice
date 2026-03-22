using Domain.Mappings;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Repositories_.IRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;

        public RegionController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            string? filterOn, string? filterBy,
            string? sortOn, bool isAscending = false,
            int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterBy))
            {
                if (!filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase) && !filterOn.Equals("RegionId", StringComparison.OrdinalIgnoreCase))
                    return BadRequest("Only 'Name' or 'RegionId' is accepted for filterOn field.");
            }
            if (!string.IsNullOrEmpty(sortOn))
            {
                if (!sortOn.Equals("Name", StringComparison.OrdinalIgnoreCase) && !sortOn.Equals("RegionId", StringComparison.OrdinalIgnoreCase))
                    return BadRequest("Only 'Name' and 'RegionId' is accepted for sortOn field.");
            }

            if (pageNumber < 1 || pageSize < 1)
                return BadRequest("PageNumber and PageSize can't be lower than 1");

            var models = await regionRepository.GetAll(filterOn, filterBy, sortOn, isAscending, pageNumber, pageSize);
            if (models is null)
                return Problem(detail: "Could not found what you're looking for.", statusCode: StatusCodes.Status404NotFound, title: "Return All Failed!");

            return Ok(models.ToDtoList());
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var domainModel = await regionRepository.GetById(id);
            if (domainModel is null)
                return Problem(
                    detail: $"Could not found Region with id: {id}",
                    instance: $"/Region/{id}",
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Find Failed!");

            return Ok(domainModel.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegionCreateRequestDto requestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requestModel = requestDto.RequestToDomain();

            var createdDomain = await regionRepository.Create(requestModel);
            if (createdDomain is null)
                return Problem(
                    detail: "Fields can not be null!",
                    statusCode: StatusCodes.Status400BadRequest,
                    title: "Create Region Failed!"
                    );

            return CreatedAtAction(nameof(GetById), new { id = createdDomain.Id }, createdDomain.ToDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RegionUpdateRequestDto requestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requestModel = requestDto.RequestToDomain();

            var updatedModel = await regionRepository.Update(id, requestModel);
            if (updatedModel is null)
                return Problem(
                    detail: $"Region with id: {id} not found",
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Update Region Failed");

            return Ok(updatedModel.ToDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var domainModel = await regionRepository.Delete(id);
            if (domainModel is null)
                return Problem(
                    detail: $"Region with id: {id} not found",
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Delete Failed"
                    );

            return NoContent();
        }
    }
}
