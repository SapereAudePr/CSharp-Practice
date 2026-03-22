using Domain.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.DTO;

public class RegionDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1-100 characters.")]
    public string Name { get; set; } = null!;

    public DateTimeOffset CreationTime { get; set; }

    [Required]
    public int CityId { get; set; }

    
}
