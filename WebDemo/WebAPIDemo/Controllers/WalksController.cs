using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.CustomActionFilters;
using WebAPIDemo.Models.Domain;
using WebAPIDemo.Models.DTO;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this._walkRepository = walkRepository;
            this._mapper = mapper;
        }

        // GET: api/walks=filterOn=Name&filterQuery=Track
        [HttpGet] 
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool isAscending = false)
        {
            var walkDomainModel = await _walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending);

            return Ok(_mapper.Map<List<WalkDto>>(walkDomainModel));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetByIdAsync(id);

            if (walkDomainModel is null)
                return NotFound();

            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto requestDto)
        {
            var walkDomainModel = _mapper.Map<Walk>(requestDto);

            walkDomainModel = await _walkRepository.CreateAsync(walkDomainModel);

            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = walkDomainModel.Id }, walkDto);
        }

        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromBody] UpdateWalkRequestDto requestDto, [FromRoute] Guid id)
        {
            var walkDomainModel = _mapper.Map<Walk>(requestDto);

            walkDomainModel = await _walkRepository.UpdateAsync(walkDomainModel, id);

            if (walkDomainModel is null)
                return NotFound();

            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var walkDomainModel = _walkRepository.DeleteAsync(id);

            if (walkDomainModel is null)
                return NotFound();

            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }
    }
}
