using Domain.Common;

namespace Application.ValueObjects;

public record EmailAddress
{
    public string Value { get; }

    public EmailAddress(string mailAddress)
    {
        Value = mailAddress.ValidateEmailRegex(normalize: true);
    }
}


