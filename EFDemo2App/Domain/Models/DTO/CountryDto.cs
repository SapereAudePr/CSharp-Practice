namespace Domain.Models.DTO;

public class CountryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset CreationTime { get; set; }
}
