namespace Domain.Models.Domain;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset CreationTime { get; set; }
}
