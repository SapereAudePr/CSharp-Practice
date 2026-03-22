using Domain.Models.Domain;
using Domain.Models.DTO;

namespace Domain.Mappings;

public static class RegionMap
{
    public static List<RegionDto> ToDtoList(this List<Region> regions)
    {
        return regions.Select(x => x.ToDto()).ToList();
    }

    public static RegionDto ToDto(this Region region)
    {
        return new RegionDto()
        {
            Id = region.Id,
            Name = region.Name,
            CreationTime = region.CreationTime,
            CityId = region.CityId
        };
    }

    public static Region ToDomain(this RegionDto regionDto)
    {
        return new Region()
        {
            Name = regionDto.Name,
            CityId = regionDto.CityId
        };
    }

    public static Region RequestToDomain(this RegionCreateRequestDto requestDto)
    {
        return new Region()
        {
            Name = requestDto.Name,
            CityId = requestDto.CityId
        };
    }

    public static Region RequestToDomain(this RegionUpdateRequestDto requestDto)
    {
        return new Region()
        {
            Name = requestDto.Name,
            CityId = requestDto.CityId
        };
    }
}
