using Application.Common;
using Application.Enums;
using Application.ValueObjects;

namespace Application.Entities;
public abstract class Personnel : AuditableEntity
{
    public Gender Gender { get; set; }
    public DateTime ShiftStart { get; set; }
    public DateTime ShiftEnd { get; set; }
    public Department Department { get; set; } = null!;
    public int DepartmentId { get; set; }
    public PhoneNumber PhoneNumber { get; set; } = null!;
    public EmailAddress EmailAddress { get; set; } = null!;
}
