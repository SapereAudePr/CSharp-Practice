namespace Practice2385.BankTransferSystem;

public class Result<T>
{
    public T? Value { get; }
    public string? ErrorMessage { get; }
    public bool IsSuccess { get; }

    public Result(
        T? value, string? errorMessage, bool isSuccess)
    {
        Value = value;
        ErrorMessage = errorMessage;
        IsSuccess = isSuccess;
    }

    public static Result<T> Success(T? value)
    {
        return new Result<T>(value, null, true);
    }

    public static Result<T> Fail(string errorMessage)
    {
        return new Result<T>(default, errorMessage, false);
    }
}
