using Domain.Common;

namespace Application.Entities;

public class Doctor : Personnel
{
    public Doctor(string specialization, string licenseNumber)
    {
        Specialization = specialization;
        LicenseNumber = licenseNumber;
    }

    private Doctor() { }

    private string _specialization = null!;

    public string Specialization
    {
        get => _specialization;
        set
        {
            _specialization = Guard.CheckNullOrLong(value, 50);
        }
    }


    private string _licenseNumber = null!;

    public string LicenseNumber
    {
        get => _licenseNumber;
        set
        {
            _licenseNumber = Guard.CheckNullOrLong(value, 50);
        }
    }
}
