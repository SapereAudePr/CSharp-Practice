using System.ComponentModel.DataAnnotations;

namespace Domain.Models.DTO;

public class RegionDto
{
    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1-100 characters.")]
    public string Name { get; set; } = null!;

    [Required]
    public int CityId { get; set; }
}
