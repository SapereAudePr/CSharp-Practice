namespace Practice2385.ValidatorPractice2;

public record ValidationError(string field, string errorMessage);
public record ValidationResult(bool IsValid, IReadOnlyList<ValidationError> Errors)
{
    public static ValidationResult Success() =>
        new(true, []);
}

public class Validator<T>
{
    private readonly T _subject;
    private readonly List<ValidationError> _errors = new();

    public Validator(T subject) => _subject = subject;

    public void AddError(string field, string message) =>
        _errors.Add(new ValidationError(field, message));

    public ValidationResult Validate() =>
        _errors.Count == 0 ? ValidationResult.Success()
        : new(false, _errors);

    public FieldValidator<T> RuleFor(string fieldName,
        Func<T, string> selector) =>
        new(this, fieldName, selector(_subject));
}

public class FieldValidator<T>
{
    private readonly Validator<T> _parent;
    private readonly string _field;
    private readonly string _value;

    public FieldValidator(Validator<T> parent, string field, string value)
    {
        _parent = parent;
        _field = field;
        _value = value;
    }

    public FieldValidator<T> NotNull()
    {
        if (_value is null)
            _parent.AddError(_field, $"{_field} is required.");
        return this;
    }

    public FieldValidator<T> NotEmpty()
    {
        if (_value is string s && string.IsNullOrEmpty(s))
            _parent.AddError(_field, $"{_field} must not be empty.");
        return this;
    }

    public FieldValidator<T> MinLength(int min)
    {
        if (_value is string s && s.Length < min)
            _parent.AddError(_field,
                $"{_field} must be at least {min} characters long.");
        return this;
    }

    public FieldValidator<T> MaxLength(int max)
    {
        if (_value is string s && s.Length > max)
            _parent.AddError(_field,
                $"{_field} must be at most {max} characters long.");
        return this;
    }

    public Validator<T> And() => _parent;

    public ValidationResult Validate() => _parent.Validate();
}

public class Test
{
    private record Person(string Name, string Password);

    public ValidationResult Mnx()
    {
        var res = new Validator<Person>(new Person("TestName", "TestPassword"))
            .RuleFor("Name", x => x.Name)
            .NotNull()
            .MaxLength(2)
            .And()
            .RuleFor("Password", x => x.Password)
            .MinLength(2)
            .MaxLength(4)
            .NotNull()
            .Validate();

        return res;
    }
}

