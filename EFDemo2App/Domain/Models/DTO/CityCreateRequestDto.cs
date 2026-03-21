using System.ComponentModel.DataAnnotations;

namespace Domain.Models.DTO;

public class CityCreateRequestDto
{
    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Name must be between 2 - 100 characters")]
    public string Name { get; set; } = null!;

    [Required]
    public int CountryId { get; set; }
}
