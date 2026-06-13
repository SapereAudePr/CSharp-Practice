namespace Practice2385.BankTransferSystem;

public class Database
{
    public static List<Account> Accounts = new()
    {
        new Account("ACC001", "Raven", 800m),
        new Account("ACC002", "John", 1200m),
        new Account("ACC003", "Alicia", 700m)
    };
}
