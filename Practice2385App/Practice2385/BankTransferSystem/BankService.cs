namespace Practice2385.BankTransferSystem;

public static class BankService
{
    public record Accounts(Account Sender, Account Receiver, decimal Amount);

    public static Result<Account> FindAccount(string accId)
    {
        var acc = Database.Accounts.FirstOrDefault(
            x => x.Id.Equals(accId, StringComparison.OrdinalIgnoreCase));

        if (acc == default)
            return Result<Account>.Fail("Account not found");

        return Result<Account>.Success(acc);
    }

    public static Result<Account> CheckBalance(
        this Account result, decimal balance)
    {
        if (result.Balance < balance)
            return Result<Account>.Fail("Insufficient Balance!");

        return Result<Account>.Success(result);
    }

    public static Result<Accounts> FindReceiver(
        this Account result, string accId)
    {
        var receiver = Database.Accounts.FirstOrDefault(
            x => x.Id.Equals(accId, StringComparison.OrdinalIgnoreCase));

        if (receiver == default)
            return Result<Accounts>.Fail("Receiver not found!");

        var record = new Accounts(result, receiver, 0);

        return Result<Accounts>.Success(record);
    }

    public static Result<Accounts> ProcessTransfer(
        this Accounts result, decimal amount)
    {
        var sender = result.Sender;
        var receiver = result.Receiver;

        sender.Balance -= amount;
        receiver.Balance += amount;

        var record = new Accounts(sender, receiver, amount);

        return Result<Accounts>.Success(record);
    }

    public static Result<Accounts> GenerateReceipt(
        this Accounts result)
    {
        Console.WriteLine(
            $"Amount: {result.Amount} \n" +
            $"Sender Balance: {result.Sender.Balance} \n" +
            $"Receiver Balance: {result.Receiver.Balance}");

        return Result<Accounts>.Success(result);
    }
}
