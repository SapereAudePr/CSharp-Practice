using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Domain;

public class Restaurant
{
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Name must be between 2-50 characters")]
    public string Name { get; set; } = null!;

    [Range(5, 5000, ErrorMessage = "Capacity number must be between 5-5000(inclusive numbers)", MinimumIsExclusive = false, MaximumIsExclusive = false)]
    public int Capacity { get; set; }

    [Range(1, 5, ErrorMessage = "Review point must be between 1-5(inclusive numbers)", MinimumIsExclusive = false, MaximumIsExclusive = false)]
    public int ReviewPoint { get; set; }

    [Required]
    [DataType(DataType.Time)]
    public TimeOnly StartShiftTime { get; set; }

    [Required]
    [DataType(DataType.Time)]
    public TimeOnly EndShiftTime { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateOnly BuiltDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTimeOffset CreationTime { get; set; }


    // Navigation Properties
    public int RegionId { get; set; }
    public Region Region { get; set; } = null!;
}
