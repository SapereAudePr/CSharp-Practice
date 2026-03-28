namespace Domain.Entities;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public Employee Employee { get; set; } = null!;
}
