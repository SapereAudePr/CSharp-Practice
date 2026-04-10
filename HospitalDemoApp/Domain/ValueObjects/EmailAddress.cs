namespace Application.ValueObjects;

public class EmailAddress
{
    public string MailAddress { get; private set; } = null!;

    private EmailAddress() { }

    public EmailAddress(string mailAddress)
    {
        if (string.IsNullOrWhiteSpace(mailAddress) || mailAddress.Length > 254)
        {
            throw new ArgumentException("Invalid email");
        }

        MailAddress = mailAddress;
    }
}
