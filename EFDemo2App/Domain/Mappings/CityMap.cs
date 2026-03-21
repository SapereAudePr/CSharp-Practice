using Domain.Models.Domain;
using Domain.Models.DTO;

namespace Domain.Mappings;

public static class CityMap
{
    public static List<CityDto> ListToDto(this List<City> cities)
    {
        return cities.Select(x => x.ToDto()).ToList();
    }

    public static CityDto ToDto(this City city)
    {
        return new CityDto()
        {
            Id = city.Id,
            Name = city.Name,
            CountryId = city.CountryId,
            CreationTime = city.CreationTime
        };
    }

    public static City ToDomain(this CityDto cityDto)
    {
        return new City()
        {
            Name = cityDto.Name,
            CountryId = cityDto.CountryId
        };
    }

    public static City DtoToDomain(this CityCreateRequestDto requestDto)
    {
        return new City()
        {
            Name = requestDto.Name,
            CountryId = requestDto.CountryId
        };
    }

    public static City DtoToDomain(this CityUpdateRequestDto requestDto)
    {
        return new City()
        {
            Name = requestDto.Name,
            CountryId = requestDto.CountryId
        };
    }
}
