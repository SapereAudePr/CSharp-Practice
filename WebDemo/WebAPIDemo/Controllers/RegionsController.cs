using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Data;
using WebAPIDemo.Models.Domain;
using WebAPIDemo.Models.DTO;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WebDemoDbContext _webDemoDbContext;

        public RegionsController(WebDemoDbContext webDemoDbContext)
        {
            this._webDemoDbContext = webDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _webDemoDbContext.Regions.ToListAsync();

            var regionDto = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImgUrl = region.RegionImgUrl
                });
            }

            return Ok(regionDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _webDemoDbContext.Regions.
                FirstOrDefaultAsync(r => r.Id == (id));

            if (region is null)
                return NotFound();

            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImgUrl = region.RegionImgUrl
            };

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto requestDto)
        {
            var regionDomainModel = new Region()
            {
                Code = requestDto.Code,
                Name = requestDto.Name,
                RegionImgUrl = requestDto.RegionImgUrl
            };


            await _webDemoDbContext.Regions.AddAsync(regionDomainModel);
            await _webDemoDbContext.SaveChangesAsync();

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgUrl = regionDomainModel.RegionImgUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto requestDto)
        {
            var regionDomainModel = await _webDemoDbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (regionDomainModel is null)
                return NotFound();

            regionDomainModel.Code = requestDto.Code;
            regionDomainModel.Name = requestDto.Name;
            regionDomainModel.RegionImgUrl = requestDto.RegionImgUrl;

            await _webDemoDbContext.SaveChangesAsync();

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgUrl = regionDomainModel.RegionImgUrl
            };

            return Ok(regionDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionDomainModel = await _webDemoDbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (regionDomainModel is null)
                return NotFound();

            _webDemoDbContext.Regions.Remove(regionDomainModel);
            await _webDemoDbContext.SaveChangesAsync();

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgUrl = regionDomainModel.RegionImgUrl
            };

            return Ok(regionDto);
        }
    }
}
