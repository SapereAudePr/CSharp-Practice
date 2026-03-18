namespace EFDemo.Domain.Models;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset CreationTime { get; set; }

    public int CityId { get; set; }
    public City City { get; set; } = null!;
}
