namespace Practice2385.UserServicePractice;

public static class ResultExtensions
{
    public static Result<T> PrintResults<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            Console.WriteLine(
                $"Success: {result.IsSuccess} | " +
                $"Value: {result.Value}");
        else
            Console.WriteLine(
                $"Success: {result.IsSuccess} | " +
                $"Error: {result.Error}");

        return result;
    }


    public static Result<T> OnSuccess<T>(this Result<T> result, Func<T, T> func)
    {
        if (!result.IsSuccess)
            return result;

        var value = func(result.Value!);
        return Result<T>.Success(value);
    }
}
