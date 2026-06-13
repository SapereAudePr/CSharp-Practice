namespace Practice2385.UserServicePractice;

public class Result<T>
{
    public T? Value { get; }
    public bool IsSuccess { get; }
    public string? Error { get; set; }

    public Result(T? value, bool isSuccess, string? error)
    {
        Value = value;
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true, default);
    }

    public static Result<T> Failure(string? error)
    {
        return new Result<T>(default, false, error);
    }
}
