namespace Application.Entities;

public class Doctor : Personnel
{
    public string Specialization { get; set; } = null!;
    public string LicenseNumber { get; set; } = null!;
}
