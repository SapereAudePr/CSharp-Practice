using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Corporate
{
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Name must be between 1-50 characters")]
    public string Name { get; set; } = null!;

    [Range(maximum: 500000, minimum:1, ErrorMessage = "Capacity must be between 1-500000")]
    public int Capacity { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
