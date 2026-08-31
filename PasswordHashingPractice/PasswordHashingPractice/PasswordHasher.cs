using System.Security.Cryptography;

namespace PasswordHashingPractice;

public class PasswordHasher
{
    private const int SaltByteSize = 16;
    private const int IterationsCount = 100_000;
    private const int KeySizeBytes = 32;
    private static readonly HashAlgorithmName Prf = HashAlgorithmName.SHA256;

    public string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltByteSize);

        var key = Rfc2898DeriveBytes.Pbkdf2(password, salt, IterationsCount, Prf, KeySizeBytes);

        return $"{IterationsCount}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(key)}";
    }

    public bool Verify(string hashedPassword, string providedPassword)
    {
        var parts = hashedPassword.Split('.');
        if (parts.Length != 3)
            return false;

        if (!int.TryParse(parts[0], out var iterations))
            return false;

        byte[] salt, storedKey;
        try
        {
            salt = Convert.FromBase64String(parts[1]);
            storedKey = Convert.FromBase64String(parts[2]);
        }
        catch (FormatException)
        {
            return false;
        }

        var computedKey = Rfc2898DeriveBytes.Pbkdf2(providedPassword, salt, iterations, Prf, storedKey.Length);

        return CryptographicOperations.FixedTimeEquals(computedKey, storedKey);
    }
}
