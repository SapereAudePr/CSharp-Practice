namespace Practice2385.LoginSystemPainVersion;

public class UserDb
{
    public static List<User> Users = new()
    {
        new User("First", "123456789", false),
        new User("Second", "123456789", false),
        new User("Third", "123456789", true),
    };
}
