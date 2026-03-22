using Domain.Mappings;
using Domain.Models.Domain;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Repositories_.IRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantController(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? filterOn,
            [FromQuery] string? filterBy,
            [FromQuery] string? sortOn,
            [FromQuery] bool isAscending = false,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var domainModel = await restaurantRepository.GetAll(
                filterOn, filterBy,
                sortOn, isAscending,
                pageNumber, pageSize);

            return Ok(domainModel.ToListDto());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var domainModel = await restaurantRepository.GetById(id);
            if (domainModel is null)
                return Problem(
                    detail: $"Restaurant with id: {id} not found",
                    statusCode: StatusCodes.Status404NotFound,
                    title: "No Restaurant Found!");

            return Ok(domainModel.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RestaurantCreateRequestDto requestDto)
        {
            var requestDomain = requestDto.RequestToDomain();
            var domainModel = await restaurantRepository.Create(requestDomain);

            var createdDomain = await restaurantRepository.GetById(domainModel.Id);
            if (createdDomain is null)
                return NotFound();

            return CreatedAtAction(nameof(GetById), new { id = createdDomain.Id }, createdDomain.ToDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RestaurantUpdateRequestDto requestDto)
        {
            var updateDomain = await restaurantRepository.Update(id, requestDto.RequestToDomain());
            if (updateDomain is null)
                return Problem(
                    detail: "Restaurant with id: {id} not found",
                    statusCode: StatusCodes.Status404NotFound,
                    title: "No Restaurant Found!");

            return Ok(updateDomain.ToDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var domainModel = await restaurantRepository.Delete(id);
            if (domainModel is null)
                return Problem(
                   detail: "Restaurant with id: {id} not found",
                   statusCode: StatusCodes.Status404NotFound,
                   title: "No Restaurant Found!");

            return NoContent();
        }
    }
}
