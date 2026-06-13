namespace Practice2385.LoginSystemPainVersion;

public static class LoginService
{
    public record LoginResult(User User, string Token);


    public static Result<User> FindUser(string userName)
    {
        var user = UserDb.Users.Find(x => x.UserName.Equals(userName));
        if (user is null)
            return Result<User>.Fail("User not found");

        return Result<User>.Success(user);
    }

    public static Result<User> CheckPassword(User user, string password)
    {
        if (user is null)
            return Result<User>.Fail("User is null");

        return user.Password == password ?
            Result<User>.Success(user) : 
            Result<User>.Fail("Password is not correct");
    }

    public static Result<User> CheckBanned(User user)
    {
        return user.isBanned ?
            Result<User>.Fail($"{user.UserName} is banned") :
            Result<User>.Success(user);
    }

    public static Result<LoginResult> GenerateToken(User user)
    {
        string sessionToken = Guid.NewGuid().ToString();

        return Result<LoginResult>.Success(new LoginResult(user, sessionToken));
    }
}
