namespace Practice2385.BankTransferSystem;

public record Account
{
    public string Id { get; } = null!;
    public string Owner { get; } = null!;
    public decimal Balance { get; set; }

    public Account(string id, string owner, decimal balance)
    {
        Id = id;
        Owner = owner;
        Balance = balance;
    }
}