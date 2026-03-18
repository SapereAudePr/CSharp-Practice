namespace Domain.Models.Domain;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset CreationTime { get; set; }

    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
}
