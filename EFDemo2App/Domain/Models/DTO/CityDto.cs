namespace Domain.Models.DTO;

public class CityDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CountryId { get; set; }
    public DateTimeOffset CreationTime { get; set; }
}
