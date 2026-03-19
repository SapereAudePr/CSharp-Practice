using Domain.Mappings;
using Domain.Models.Domain;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories_.IRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository country)
        {
            this._countryRepository = country;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
        string? filterOn, string? filterBy,
        string? sortOn, bool orderByAscending = false,
        int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterBy))
            {
                if (!filterBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest("Only 'Name' is allowed on filterOn field.");
                }
            }

            if (!string.IsNullOrEmpty(sortOn))
            {
                if (!sortOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest("Only 'Name' is allowed on sortOn field.");
                }
            }

            var domainModel = await _countryRepository.GetAll(filterOn, filterBy, sortOn, orderByAscending, pageNumber, pageSize);

            return Ok(domainModel.ToDtoList());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var country = await _countryRepository.GetById(id);

            if (country is null)
            {
                return Problem(
                    detail: $"No Country found with the id: {id}",
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Resource Not Found"
                    );
            }

            return Ok(country.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateRequestDto requestDto)
        {
            if (requestDto is null)
                return BadRequest("Request body cannot be null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var domainModel = requestDto.ToDomain();

            domainModel = await _countryRepository.Create(domainModel);

            var countryDto = domainModel.ToDto();

            return CreatedAtAction(nameof(GetById), new { id = domainModel.Id }, countryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CountryUpdateRequestDto requestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var domainModel = requestDto.ToCountryFromUpdate();

            domainModel = await _countryRepository.Update(domainModel, id);

            if (domainModel is null)
            {
                return Problem(
                    detail: $"Could not update. No Country found with id: {id}",
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Update Failed!");
            }

            return Ok(domainModel.ToDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var domainModel = await _countryRepository.Delete(id);
            if (domainModel is null)
            {
                return Problem(
                    detail: $"Could not delete. No Country found with id: {id}",
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Delete Failed!");
            }

            return NoContent();
        }
    }
}
