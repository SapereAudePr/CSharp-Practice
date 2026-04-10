using Application.Common;
using Domain.Common;

namespace Application.Entities;

public class Hospital : AuditableEntity
{

    public Hospital(string address, ICollection<Department> departments, string mainPhoneNumber, string mainEmailAddress, DateTimeOffset builtDate)
    {
        Address = address;
        Departments = departments;
        MainPhoneNumber = mainPhoneNumber;
        MainEmailAddress = mainEmailAddress;
        BuiltDate = builtDate;
    }

    private Hospital() { }

    private string _address = null!;
    public string Address
    {
        get => _address;
        private set
        {
            _address = Guard.CheckNullOrLong(value, 256);
        }
    }

    public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    public string MainPhoneNumber { get; set; } = null!;
    public string MainEmailAddress { get; set; } = null!;

    private DateTimeOffset _builtDate;

    public DateTimeOffset BuiltDate
    {
        get => _builtDate;
        private set
        {
            if (value > DateTime.UtcNow)
                throw new ArgumentOutOfRangeException("Invalid BuiltDate");

            _builtDate = value;
        }
    }
}
