using Domain.Common;

namespace Application.Entities;

public class Janitor : Personnel
{
    public Janitor(
        string assignedZone,
        bool biohazardCertified,
        string securityClearanceLevel)
    {
        AssignedZone = assignedZone;
        BiohazardCertified = biohazardCertified;
        SecurityClearanceLevel = securityClearanceLevel;
    }

    private Janitor() { }

    private string _assignedZone = null!;

    public string AssignedZone
    {
        get => _assignedZone;
        private set
        {
            _assignedZone = Guard.CheckNullOrLong(value, 50);
        }
    }

    public bool BiohazardCertified { get; set; }


    private string _securityClearanceLevel = null!;

    public string SecurityClearanceLevel
    {
        get => _securityClearanceLevel;
        private set
        {
            _securityClearanceLevel = Guard.CheckNullOrLong(value, 50);
        }
    }
}
