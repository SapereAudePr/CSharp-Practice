using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false ,ErrorMessage = "Employee must have role/s")]
    public string Role { get; set; } = null!;


    // FKs
    public Person Person { get; set; } = null!;
    public int PersonId { get; set; }

    public Corporate Corporate { get; set; } = null!;
    public int CorporateId { get; set; }
}
