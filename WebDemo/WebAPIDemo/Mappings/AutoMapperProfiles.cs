using AutoMapper;
using WebAPIDemo.Models.Domain;
using WebAPIDemo.Models.DTO;

namespace WebAPIDemo.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, AddRegionRequestDto>().ReverseMap(); 
            CreateMap<Region, UpdateRegionRequestDto>().ReverseMap(); 
        }
    }
}
