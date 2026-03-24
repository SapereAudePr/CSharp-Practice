using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Person
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Person must have a name")]
    [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Name must be between 2-50 characters")]
    public string Name { get; set; } = null!;


    [Required(AllowEmptyStrings = false, ErrorMessage = "Person must have a last name")]
    [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Last name must be between 2-50 characters")]
    public string LastName { get; set; } = null!;

    public Employee? Employee { get; set; }
}
