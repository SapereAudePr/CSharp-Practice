using Domain.Models.Domain;
using Domain.Models.DTO;

namespace Domain.Mappings;

public static class CountryMap
{
    public static List<CountryDto> ToDtoList(this IEnumerable<Country> countries)
    {
        return countries.Select(x => x.ToDto()).ToList();
    }

    public static Country ToDomain(this CountryCreateRequestDto requestDto)
    {
        return new Country()
        {
            Name = requestDto.Name
        };
    }

    public static CountryDto ToDto(this Country country)
    {
        return new CountryDto()
        {
            Id = country.Id,
            Name = country.Name,
            CreationTime = country.CreationTime
        };
    }
}
