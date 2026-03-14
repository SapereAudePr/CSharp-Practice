using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models.Domain;
using WebAPIDemo.Models.DTO;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this._regionRepository = regionRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();

            return Ok(_mapper.Map<List<Region>>(regions));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);

            if (region is null)
                return NotFound();

            return Ok(_mapper.Map<RegionDto>(region));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto requestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(requestDto);

            regionDomainModel = await _regionRepository.CreateRegionAsync(regionDomainModel);

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto requestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(requestDto);

            regionDomainModel = await _regionRepository.UpdateRegionAsync(regionDomainModel, id);

            if (regionDomainModel is null)
                return NotFound();

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteRegionAsync(id);

            if (regionDomainModel is null)
                return NotFound();

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
