namespace Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Role { get; set; } = null!;

    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }


    // FKs
    public Person Person { get; set; } = null!;
    public int PersonId { get; set; }

    public Corporate Corporate { get; set; } = null!;
    public int CorporateId { get; set; }
}
