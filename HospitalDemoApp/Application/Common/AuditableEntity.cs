namespace Application.Common;

public abstract class AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public string CreatedBy { get; set; } = null!;
    public string UpdatedBy { get; set; } = null!;
}
