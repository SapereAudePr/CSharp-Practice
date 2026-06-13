namespace Practice2385.LoginSystemPainVersion;

public static class ResultExtensions
{
    public static Result<T> Print<T>(this Result<T> result)
    {
        if (!result.IsSuccess)
            Console.WriteLine(result.ErrorMessage);

        else if (result.IsSuccess &&
            result.Value is User user)
            Console.WriteLine(
                $"User Name: {user.UserName} | " +
                $"Password: {user.Password} | " +
                $"Is Banned: {user.isBanned}");

        else if (
            result.IsSuccess &&
            result.Value is LoginService.LoginResult loginResult)
            Console.WriteLine($"UserName: {loginResult.User.UserName} | " +
                $"Password: {loginResult.User.Password} | " +
                $"IsBanned: {loginResult.User.isBanned} | " +
                $"Token: {loginResult.Token}");

        return result;
    }

    public static Result<T> Print<T>(
        this Result<T> result, Func<T, string>? func = null)
    {
        if (!result.IsSuccess)
            Console.WriteLine($"Error: {result.ErrorMessage}");

        else if (func is not null)
            Console.WriteLine(func(result.Value!));

        else
            Console.WriteLine(result.Value);

        return result;
    }

    public static Result<TResult> OnSuccess<T, TResult>(
        this Result<T> result, Func<T, TResult> func)
    {
        if (!result.IsSuccess)
            return Result<TResult>.Fail(result.ErrorMessage!);

        var newValue = func(result.Value!);

        return Result<TResult>.Success(newValue);
    }

    public static Result<TResult> OnSuccess<T, TResult>(
        this Result<T> result, Func<T, Result<TResult>> func)
    {
        if (!result.IsSuccess)
            return Result<TResult>.Fail(result.ErrorMessage!);

        return func(result.Value!);
    }
}
