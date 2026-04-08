using Application.DTO;
using FluentValidation;

namespace Application.Validators;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required")
            .Length(5).WithMessage("CustomerId must be 5 characters");

        RuleFor(x => x.EmployeeId)
            .NotNull().WithMessage("EmployeeId is required");

        RuleFor(x => x.OrderDate)
            .NotNull().WithMessage("OrderDate is required");

        RuleFor(x => x.Freight)
            .GreaterThanOrEqualTo(0).When(x => x.Freight.HasValue);

        RuleFor(x => x.ShipName)
            .MaximumLength(40);

        RuleFor(x => x.ShipAddress)
            .MaximumLength(60);

        RuleFor(x => x.ShipCity)
            .MaximumLength(15);

        RuleFor(x => x.ShipPostalCode)
            .MaximumLength(10);

        RuleFor(x => x.ShipCountry)
            .MaximumLength(15);

        // Business rule example
        RuleFor(x => x.RequiredDate)
            .GreaterThan(x => x.OrderDate)
            .When(x => x.OrderDate.HasValue && x.RequiredDate.HasValue)
            .WithMessage("RequiredDate must be after OrderDate");
    }
}