using Domain.Common;

namespace Application.Entities;

public class Nurse : Personnel
{
    public Nurse(string certificationLevel,
        string assignedWard,
        string shiftType,
        bool isHeadNurse = false)
    {
        CertificationLevel = certificationLevel;
        AssignedWard = assignedWard;
        ShiftType = shiftType;
        IsHeadNurse = isHeadNurse;
    }

    private Nurse() { }

    public bool IsHeadNurse { get; set; }

    private string _certificationLevel = null!;

    public string CertificationLevel 
    { 
        get => _certificationLevel;
        private set
        {
            _certificationLevel = Guard.CheckNullOrLong(value, 30);
        } 
    }

    private string _assignedWard = null!;
    public string AssignedWard
    {
        get => _assignedWard;
        private set
        {
            _assignedWard = Guard.CheckNullOrLong(value, 30);
        }
    }


    private string _shiftType = null!;
    public string ShiftType
    {
        get => _shiftType;
        private set
        {
            _shiftType = Guard.CheckNullOrLong(value, 30);
        }
    }
}