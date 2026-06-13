namespace Practice2385.OrderProcessingPractice;

public class Result<T>
{
    public T? Value { get; }
    public string? ErrorMessage { get; }
    public bool IsSuccess { get; }

    public Result(T? value, string? errorMessage, bool isSuccess)
    {
        Value = value;
        ErrorMessage = errorMessage;
        IsSuccess = isSuccess;
    }


    public static Result<T> Success(T? result)
    {
        return new Result<T>(result, null, true);
    }

    public static Result<T> Failure(string? errorMessage)
    {
        return new Result<T>(default, errorMessage, false);
    }
}
