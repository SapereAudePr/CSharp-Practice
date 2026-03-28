using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Corporate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Range(maximum: 500000, minimum:1, ErrorMessage = "Capacity must be between 1-500000")]
    public int Capacity { get; set; }

    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
