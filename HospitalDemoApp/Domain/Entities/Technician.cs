using Domain.Common;

namespace Application.Entities;

public class Technician : Personnel
{
    private string _technicalCategory = null!;
    private string _equipmentSpecialty = null!;
    private string _certificationNumber = null!;

    public Technician(string technicalCategory,
        string equipmentSpecialty,
        string certificationNumber)
    {
        TechnicalCategory = technicalCategory;
        EquipmentSpecialty = equipmentSpecialty;
        CertificationNumber = certificationNumber;
    }

    private Technician() { }

    

    public string TechnicalCategory
    {
        get => _technicalCategory;
        private set
        {
            _technicalCategory = Guard.CheckNullOrLong(value, 30);
        }
    }

   

    public string EquipmentSpecialty 
    {
        get => _equipmentSpecialty;
        private set
        {
            _equipmentSpecialty = Guard.CheckNullOrLong(value, 30);
        }
    }


    

    public string CertificationNumber 
    {
        get => _certificationNumber;
        private set
        {
            _certificationNumber = Guard.CheckNullOrLong(value, 80);
        }
    }
}