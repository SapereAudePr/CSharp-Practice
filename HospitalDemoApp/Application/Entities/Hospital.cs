using Application.Common;

namespace Application.Entities;

public class Hospital : AuditableEntity
{
    public string Address { get; set; } = null!;
    public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    public string MainPhoneNumber { get; set; } = null!;
    public string MainEmailAddress { get; set; } = null!;
    public DateTimeOffset BuiltDate { get; set; }
}
