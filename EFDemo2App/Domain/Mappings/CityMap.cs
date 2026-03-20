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
            Name = city.Name,
            CountryId = city.CountryId
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
}
