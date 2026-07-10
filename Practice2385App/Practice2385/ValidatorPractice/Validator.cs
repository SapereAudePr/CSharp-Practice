namespace Practice2385.ValidatorPractice;

public record ValidationError(string Field, string Message);

public record ValidationResult(bool isValid, IReadOnlyList<ValidationError> Errors)
{
    public static ValidationResult Success =>
        new ValidationResult(true, Array.Empty<ValidationError>());
}

public class Validator<T>
{
    private readonly T _subject;
    private readonly List<ValidationError> _errors = [];

    public Validator(T subject) => _subject = subject;

    public void AddError(string field, string message) =>
        _errors.Add(new ValidationError(field, message));

    public ValidationResult Validate() =>
        _errors.Count == 0 ? ValidationResult.Success
        : new ValidationResult(false, _errors);

    public FieldValidator<T> RuleFor(string fieldName, Func<T, string> selector) =>
        new FieldValidator<T>(this, fieldName, selector(_subject));
}

public class FieldValidator<T>
{
    private readonly Validator<T> _parent;
    private readonly string _field;
    private readonly string _value;

    public FieldValidator(
        Validator<T> parent, string field, string value)
    {
        _parent = parent;
        _field = field;
        _value = value;
    }

    public FieldValidator<T> NotEmpty()
    {
        if (_value is string s && string.IsNullOrWhiteSpace(s))
            _parent.AddError(_field, $"{_field} is required");

        return this;
    }

    public FieldValidator<T> MinLength(int min)
    {
        if (_value is string s && s.Length < min)
            _parent.AddError(_field, $"{_field} must be higher than {min}");

        return this;
    }

    public FieldValidator<T> MaxLength(int max)
    {
        if (_value is string s && s.Length > max)
            _parent.AddError(_field, $"{_field} must be lower than {max}");

        return this;
    }
}

public class Test
{
    private record Person(string Name, string Email);

    public void TestMethod()
    {
        //var result = new Validator<Person>(new Person("TestName", "testemail@test.com"))
        //    .RuleFor("Name", x => x.Name)
        //    .NotEmpty()
        //    .MinLength(10)
            
    }
}
