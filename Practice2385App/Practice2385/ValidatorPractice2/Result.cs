namespace Practice2385.ValidatorPractice2;

public class Result<T>
{
    public T? Value { get; }
    public bool IsValid { get; }
    public string? ErrorMessage { get; }

    public Result(T? value, bool isValid, string? errorMessage)
    {
        Value = value;
        IsValid = isValid;
        ErrorMessage = errorMessage;
    }

    public static Result<T> Success(T value) =>
        new(value, true, null);

    public static Result<T> Fail(string? errorMessage) =>
        new(default, false, errorMessage);
}
