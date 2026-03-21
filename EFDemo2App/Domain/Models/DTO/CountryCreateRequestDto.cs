using System.ComponentModel.DataAnnotations;

namespace Domain.Models.DTO;

public class CountryCreateRequestDto
{
    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Name must be between 2 - 100 characters")]
    public string Name { get; set; } = null!;
}
