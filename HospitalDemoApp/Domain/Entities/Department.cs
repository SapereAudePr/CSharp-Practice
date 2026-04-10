using Application.Common;
using Application.ValueObjects;

namespace Application.Entities;

public class Department : AuditableEntity
{
    public Hospital Hospital { get; set; } = null!;
    public int HospitalId { get; set; }
    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    public ICollection<EmailAddress> EmailAddresses { get; set; } = new List<EmailAddress>();
    public ICollection<Personnel> Personnel { get; set; } = new HashSet<Personnel>();
}
