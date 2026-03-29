using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CustomerId { get; set; }
        public string? Surname { get; set; }
        public int CreditScore { get; set; }
        public string? Geography { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public int Tenure { get; set; }
        public decimal Balance { get; set; }
        public int NumOfProducts { get; set; }
        public bool HasCrCard { get; set; }
        public bool IsActiveMember { get; set; }
        public decimal EstimatedSalary { get; set; }
        public bool Exited { get; set; }
    }
}