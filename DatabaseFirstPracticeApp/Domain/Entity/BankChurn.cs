using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web;

[Table("Bank_Churn")]
public partial class BankChurn
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(50)]
    public string Surname { get; set; } = null!;

    public short CreditScore { get; set; }

    [StringLength(50)]
    public string Geography { get; set; } = null!;

    [StringLength(50)]
    public string Gender { get; set; } = null!;

    public byte Age { get; set; }

    public byte Tenure { get; set; }

    [Column(TypeName = "decimal(18, 10)")]
    public decimal Balance { get; set; }

    public byte NumOfProducts { get; set; }

    public bool HasCrCard { get; set; }

    public bool IsActiveMember { get; set; }

    public double EstimatedSalary { get; set; }

    public bool Exited { get; set; }
}
