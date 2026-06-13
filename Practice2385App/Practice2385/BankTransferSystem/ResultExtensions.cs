namespace Practice2385.BankTransferSystem;

public static class ResultExtensions
{
    public static Result<T> Print<T>(this Result<T> result, Func<T, string> format)
    {
        if (!result.IsSuccess)
            Console.WriteLine($"Error: {result.ErrorMessage}");
        else if (format is null)
            Console.WriteLine(format(result.Value!));
        else
            Console.WriteLine(result.Value!);

        return result;
    }

    public static Result<TResult> OnSuccess<T, TResult>(
        this Result<T> result, Func<T, Result<TResult>> func)
    {
        if (!result.IsSuccess)
            return Result<TResult>.Fail(result.ErrorMessage!);

        return func(result.Value!);
    }
}