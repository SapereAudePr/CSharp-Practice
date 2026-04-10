namespace Domain.Common;

public static class Guard
{
    public static string CheckNullOrLong(string value, int? allowedLength)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException($"{value.ToUpper()} can't be null");

        if (value.Length > allowedLength)
            throw new ArgumentOutOfRangeException($"{value.ToUpper()} can't exceed {allowedLength} characters");

        return value.Trim();
    }

    public static string CheckNull(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException($"{value.ToUpper()} can't be null");

        return value.Trim();
    }
}
