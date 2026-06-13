namespace Practice2385.UserServicePractice;

public static class UserService
{
    public static Result<User> Register(string name, string surname, string password)
    {
        var user = new User(name, surname, password);

        if (user.Name.Length < 3 || user.Name.Length > 20)
            return Result<User>.Failure("Name must be between 3 and 20 characters.");

        if (user.Surname.Length < 3 || user.Surname.Length > 20)
            return Result<User>.Failure("Surname must be between 3 and 20 characters.");

        if (user.Password.Length < 8 || user.Password.Length > 30)
            return Result<User>.Failure("Password must be between 8 and 30 characters.");

        return Result<User>.Success(user);
    }
}
