using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Data;
using WebAPIDemo.Models.Domain;
using WebAPIDemo.Models.DTO;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //https://localhost:7234/api/regions
    public class RegionsController : ControllerBase
    {
        private readonly WebDemoDbContext _webDemoDbContext;

        public RegionsController(WebDemoDbContext webDemoDbContext)
        {
            this._webDemoDbContext = webDemoDbContext;
        }

        // URL GET: https://localhost:7234/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _webDemoDbContext.Regions.ToList();

            if (regions is null)
                return NotFound();

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

        // URL GET: https://localhost:7234/api/regions/{id}
        [HttpGet("{id:Guid}")]
        // Route parameter rule : {parameterName:constraint}
        //[Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = _webDemoDbContext.Regions.
                FirstOrDefault(r => r.Id == (id));

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
        public IActionResult CreateRegion([FromBody] AddRegionRequestDto requestDto)
        {
            var regionDomainModel = new Region()
            {
                Code = requestDto.Code,
                Name = requestDto.Name,
                RegionImgUrl = requestDto.RegionImgUrl
            };


            _webDemoDbContext.Regions.Add(regionDomainModel);
            _webDemoDbContext.SaveChanges();

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgUrl = regionDomainModel.RegionImgUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }
    }
}
