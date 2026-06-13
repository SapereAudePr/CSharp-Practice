namespace Practice2385.OrderProcessingPractice;

public static class ResultExtensions
{
    public static Result<T> Print<T>(this Result<T> result)
    {
        if (!result.IsSuccess)
        {
            Console.WriteLine($"{result.ErrorMessage}");
        }
        else if (result.IsSuccess && result.Value is Order order)
        {
            Console.WriteLine(
                $"Product: {order.ProductName} " +
                $"Total Price: {order.TotalPrice}");
        }
        else
        {
            Console.WriteLine($"Total Price: {result.Value}");
        }

        return result;
    }

    public static Result<TResult> OnSuccess<T, TResult>(
        this Result<T> result, Func<T, TResult> func)
    {
        if (!result.IsSuccess)
            return Result<TResult>.Failure(result.ErrorMessage);

        var x = func(result.Value!);
        return Result<TResult>.Success(x);
    }
}
