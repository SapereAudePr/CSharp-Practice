namespace Practice2385.LoginSystemPainVersion;

public record User(
    string UserName, string Password, bool isBanned = false);
