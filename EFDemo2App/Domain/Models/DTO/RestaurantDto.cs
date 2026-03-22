using System.ComponentModel.DataAnnotations;

namespace Domain.Models.DTO;

public class RestaurantDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public int ReviewPoint { get; set; }

    public TimeOnly StartShiftTime { get; set; }

    public TimeOnly EndShiftTime { get; set; }

    public DateOnly BuiltDate { get; set; }

    public DateTimeOffset CreationTime { get; set; }

    public int RegionId { get; set; }
    public int CityId { get; set; }
    public int CountryId { get; set; }

    public string? RegionName { get; set; }
    public string? CityName { get; set; }
    public string? CountryName { get; set; }
}
