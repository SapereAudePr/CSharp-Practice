using Domain.Common;

namespace Application.ValueObjects;

public record EmailAddress
{
    public string Value { get; } = null!;
    private EmailAddress() { }

    public EmailAddress(string value)
    {
        Value = value.ValidateEmailRegex(normalize: true);
    }
}


